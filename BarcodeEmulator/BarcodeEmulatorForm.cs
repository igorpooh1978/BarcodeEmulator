using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace BarcodeEmulator
{
    public partial class BarcodeEmulatorForm : Form
    {
        private ScreenCapture objScreenCapture;

        public BarcodeEmulatorForm()
        {
            InitializeComponent();
            objScreenCapture = new ScreenCapture();

            var hk = new Hotkey(Keys.Z, shift: true, control: true, alt: false, windows: false);
            hk.Pressed += HotkeyPressed;
            textBox2.Text = hk.ToString();
            hk.Register(this);
        }

        private void HotkeyPressed(object sender, HandledEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("You have to add some strings to the list first.", "Fail", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            //var endKey = Keys.None;

            //if (endsWithComboBox.SelectedIndex > 0)
            //    Enum.TryParse(endsWithComboBox.SelectedItem.ToString(), out endKey);


            // do the delayed key sending in a separate thread so we don't hang the window
            ThreadStart starter = () => StartSending(textBox1.Text, (int)delayNumeric.Value);
            var t = new Thread(starter) { Name = "Sending keys " + textBox1.Text };
            t.Start();
        }

        private static void StartSending(string text, int delay, Keys endKey = Keys.None)
        {
            var sendKey = string.Empty;
            foreach (var s in text.Select(character => character.ToString()))
            {
                switch (s)
                {
                    case "{":
                    case "}":
                    case "+":
                    case "^":
                    case "%":
                    case "(":
                    case ")":
                    case "[":
                    case "]":
                        sendKey += $"{{{s}}}";
                        break;
                    default:
                        sendKey += s;
                        break;
                }
            }

            Debug.WriteLine("{0} Sending text '{1}'", DateTime.Now.ToString("HH:mm:ss.fff"), sendKey);

            SendKeys.SendWait(sendKey);
            SendKeys.Flush();
            Thread.Sleep(delay);
            // if configured, send an 'end' key to signal that we're at the end of the barcode
            if (endKey != Keys.None)
                SendKeys.SendWait("{" + Enum.GetName(typeof(Keys), endKey) + "}");

            // beep!
            System.Media.SystemSounds.Beep.Play();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            objScreenCapture.SetCanvas();

            var image = objScreenCapture.GetSnapShot();
            using (image)
            {
                LuminanceSource source;
                source = new BitmapLuminanceSource(image);
                BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
                Result result = new MultiFormatReader().decode(bitmap);
                if (result != null)
                {
                    textBox1.Text = result.Text;
                }
                else
                {
                    MessageBox.Show("");
                }
            }
        }
    }
}