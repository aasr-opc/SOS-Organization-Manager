using SOS_Organization_Manager;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace SOSOrganizationManager
{
    public partial class MapViewer : Form
    {
        public MapViewer()
        {
            InitializeComponent();

            this.textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            this.textBox1.MouseDoubleClick += TextBox1_MouseDoubleClick;
        }

        private void MapViewer_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::SOS_Organization_Manager.Properties.Resources._0008;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "##o##'N,##o##'E";
            this.textBox2.Text = String.Empty;
            this.textBox2.BackColor = Color.Aqua;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '°' && e.KeyChar != '\'' && e.KeyChar != '\b'
                && e.KeyChar != 'N' && e.KeyChar != 'S' && e.KeyChar != 'E' && e.KeyChar != 'W')
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Clipboard.SetText(textBox1.Text);
            }
        }

        private void TextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int clickedIndex = textBox1.GetCharIndexFromPosition(e.Location);

            if (clickedIndex < 0 || clickedIndex >= textBox1.Text.Length) return;

            char clickedChar = textBox1.Text[clickedIndex];

            if (clickedChar == '#')
            {
                if (clickedIndex + 1 < textBox1.Text.Length && textBox1.Text[clickedIndex + 1] == '#')
                {
                    textBox1.Select(clickedIndex, 2);
                    return;
                }

                else if (clickedIndex - 1 >= 0 && textBox1.Text[clickedIndex - 1] == '#')
                {
                    textBox1.Select(clickedIndex - 1, 2);
                    return;
                }
            }

            if (clickedChar == '°' || clickedChar == '\'' || clickedChar == '*' || clickedChar == 'o')
            {
                textBox1.SelectionLength = 0;
                return;
            }

            int startIndex = -1;
            int endIndex = -1;

            for (int i = clickedIndex; i >= 0; i--)
            {
                if (!char.IsDigit(textBox1.Text[i]))
                {
                    startIndex = i + 1;
                    break;
                }
            }

            if (startIndex == -1)
            {
                startIndex = 0;
            }

            for (int i = clickedIndex; i < textBox1.Text.Length; i++)
            {
                if (!char.IsDigit(textBox1.Text[i]))
                {
                    endIndex = i;
                    break;
                }
            }

            if (endIndex == -1)
            {
                endIndex = textBox1.Text.Length;
            }

            textBox1.Select(startIndex, endIndex - startIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            var regex = new Regex(@"(\d+)o(\d+)'([NS]),\s*(\d+)o(\d+)'([EW])");
            var match = regex.Match(input);

            if (!match.Success)
            {
                MessageBox.Show("Invalid format. Please enter coordinates in the format: 10o53'S,145o7'E");
                return;
            }

            int latDegrees = int.Parse(match.Groups[1].Value);
            int latMinutes = int.Parse(match.Groups[2].Value);
            bool isSouth = match.Groups[3].Value.ToUpper() == "S";

            int longDegrees = int.Parse(match.Groups[4].Value);
            int longMinutes = int.Parse(match.Groups[5].Value);
            bool isEast = match.Groups[6].Value.ToUpper() == "E";

            int mapID = 1;
            int mapWidth = 5120;
            int mapHeight = 4096;

            var result = SextantHelper.ReverseLookup(mapID, mapWidth, mapHeight, longDegrees, latDegrees, longMinutes, latMinutes, isEast, isSouth);

            textBox2.Text = $"X: {result.Item1}, Y: {result.Item2}";
            textBox2.BackColor = Color.LightGreen;
        }

        public static class SextantHelper
        {
            public static bool ComputeMapDetails(int mapID, int mapWidth, int mapHeight, int x, int y, out int xCenter, out int yCenter)
            {
                if (mapID < 0)
                {
                    xCenter = yCenter = 0;
                    return false;
                }

                if (mapID == 1 || mapID == 0)
                {
                    if (x >= 0 && y >= 0 && x < 5120 && y < 4096)
                    {
                        xCenter = 1323;
                        yCenter = 1624;
                    }
                    else if (x >= 5120 && y >= 2304 && x < 6144 && y < 4096)
                    {
                        xCenter = 5936;
                        yCenter = 3112;
                    }
                    else
                    {
                        xCenter = yCenter = 0;
                        return false;
                    }
                }
                else if (x >= 0 && y >= 0 && x < mapWidth && y < mapHeight)
                {
                    xCenter = 1323;
                    yCenter = 1624;
                }
                else
                {
                    xCenter = yCenter = 0;
                    return false;
                }

                return true;
            }

            public static Tuple<int, int> ReverseLookup(int mapID, int mapWidth, int mapHeight, int xLong, int yLat, int xMins, int yMins, bool xEast, bool ySouth)
            {
                if (mapID < 0)
                    return Tuple.Create(0, 0);

                if (!ComputeMapDetails(mapID, mapWidth, mapHeight, 0, 0, out var xCenter, out var yCenter))
                    return Tuple.Create(0, 0);

                var absLong = xLong + (xMins / 60.0);
                var absLat = yLat + (yMins / 60.0);

                if (!xEast)
                    absLong = 360.0 - absLong;

                if (!ySouth)
                    absLat = 360.0 - absLat;

                var x = xCenter + (int)(absLong * mapWidth / 360.0);
                var y = yCenter + (int)(absLat * mapHeight / 360.0);

                if (x < 0)
                    x += mapWidth;
                else if (x >= mapWidth)
                    x -= mapWidth;

                if (y < 0)
                    y += mapHeight;
                else if (y >= mapHeight)
                    y -= mapHeight;

                return Tuple.Create(x, y);
            }

            public static bool Format(int mapID, int mapWidth, int mapHeight, int x, int y, ref int xLong, ref int yLat, ref int xMins, ref int yMins, ref bool xEast, ref bool ySouth)
            {
                if (mapID < 0)
                    return false;

                if (!ComputeMapDetails(mapID, mapWidth, mapHeight, x, y, out var xCenter, out var yCenter))
                    return false;

                var absLong = (x - xCenter) * 360.0 / mapWidth;
                var absLat = (y - yCenter) * 360.0 / mapHeight;

                if (absLong > 180.0)
                    absLong = -180.0 + (absLong % 180.0);

                if (absLat > 180.0)
                    absLat = -180.0 + (absLat % 180.0);

                bool east = absLong >= 0, south = absLat >= 0;

                if (absLong < 0.0)
                    absLong = -absLong;

                if (absLat < 0.0)
                    absLat = -absLat;

                xLong = (int)absLong;
                yLat = (int)absLat;

                xMins = (int)(absLong % 1.0 * 60);
                yMins = (int)(absLat % 1.0 * 60);

                xEast = east;
                ySouth = south;

                return true;
            }

            public static string Format(int mapID, int mapWidth, int mapHeight, int x, int y)
            {
                int xLong = 0, yLat = 0;
                int xMins = 0, yMins = 0;
                bool xEast = false, ySouth = false;

                if (Format(mapID, mapWidth, mapHeight, x, y, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth))
                {
                    return $"{yLat}o {yMins}'{(ySouth ? "S" : "N")},{xLong}o {xMins}'{(xEast ? "E" : "W")}";
                }

                return String.Empty;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form CreditForm = new CreditForm();
            CreditForm.ShowDialog();
        }


        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form CreditForm = new CreditForm();
            CreditForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            var regex = new Regex(@"(\d+)o(\d+)'([NS]),\s*(\d+)o(\d+)'([EW])");
            var match = regex.Match(input);

            if (!match.Success)
            {
                MessageBox.Show("Invalid format. Please enter coordinates in the format: 25o29'S,92o44'W");
                return;
            }

            int latDegrees = int.Parse(match.Groups[1].Value);
            char latDirection = match.Groups[3].Value[0];
            int longDegrees = int.Parse(match.Groups[4].Value);
            char longDirection = match.Groups[6].Value[0];
            string range = DetermineRange(latDegrees, latDirection, longDegrees, longDirection);

            MessageBox.Show($"Place This Item In Bag: {range}");
            textBox2.Text = $"{range}";
            textBox2.BackColor = Color.LightGreen;
        }

        private string DetermineRange(int latDegrees, char latDirection, int longDegrees, char longDirection)
        {
            #region SOS Organization Bag Row 1: 'N1-N4' 

            if (latDirection == 'N' && latDegrees >= 0 && latDegrees <= 142)
            {
                if (longDirection == 'E')
                {
                    if (longDegrees >= 0 && longDegrees <= 92)
                    {
                        return "N2";
                    }
                    else if (longDegrees >= 91 && longDegrees <= 179)
                    {
                        return "N3";
                    }
                }
                else if (longDirection == 'W')
                {
                    if (longDegrees >= 0 && longDegrees <= 92)
                    {
                        return "N1";
                    }
                    else if (longDegrees >= 93 && longDegrees <= 180)
                    {
                        return "N4";
                    }
                }
            }

            #endregion

            #region SOS Organization Bag Row 2: 'C1-C4'

            else if (latDirection == 'S' && latDegrees >= 0 && latDegrees <= 90)
            {
                if (longDirection == 'E')
                {
                    if (longDegrees >= 0 && longDegrees <= 92)
                    {
                        return "C2";
                    }
                    else if (longDegrees >= 91 && longDegrees <= 179)
                    {
                        return "C3";
                    }
                }
                else if (longDirection == 'W')
                {
                    if (longDegrees >= 0 && longDegrees <= 92)
                    {
                        return "C1";
                    }
                    else if (longDegrees >= 93 && longDegrees <= 180)
                    {
                        return "C4";
                    }
                }
            }

            #endregion

            #region SOS Organization Bag Row 3: 'S1-S4'

            else if (latDirection == 'N' && latDegrees >= 143 && latDegrees <= 180)
            {
                if (longDirection == 'E')
                {
                    if (longDegrees >= 0 && longDegrees <= 92)
                    {
                        return "S2";
                    }
                    else if (longDegrees >= 91 && longDegrees <= 179)
                    {
                        return "S3";
                    }
                }
                else if (longDirection == 'W')
                {
                    if (longDegrees >= 0 && longDegrees <= 92)
                    {
                        return "S1";
                    }
                    else if (longDegrees >= 93 && longDegrees <= 180)
                    {
                        return "S4";
                    }
                }
            }
            else if (latDirection == 'S' && latDegrees >= 90 && latDegrees <= 179)
            {
                if (longDirection == 'E')
                {
                    if (longDegrees >= 0 && longDegrees <= 92)
                    {
                        return "S2";
                    }
                    else if (longDegrees >= 91 && longDegrees <= 179)
                    {
                        return "S3";
                    }
                }
                else if (longDirection == 'W')
                {
                    if (longDegrees >= 0 && longDegrees <= 92)
                    {
                        return "S1";
                    }
                    else if (longDegrees >= 93 && longDegrees <= 180)
                    {
                        return "S4";
                    }
                }
            }

            #endregion

            return "Invalid Coordinates";
        }

        private void britanniaOSIColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::SOS_Organization_Manager.Properties.Resources._0007;
        }

        private void britanniaOSIBWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::SOS_Organization_Manager.Properties.Resources._0009;
        }

        private void britanniaOSIDefaultColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::SOS_Organization_Manager.Properties.Resources._0008;
        }

        private void britanniaOSIEasyOnTheEyesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::SOS_Organization_Manager.Properties.Resources._0010;
        }
    }
}