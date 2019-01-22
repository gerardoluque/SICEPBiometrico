using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WIA;
using System.Windows.Forms;

namespace ScannerDemo
{
    class Scanner
    {
        private readonly DeviceInfo _deviceInfo;


        public Scanner(DeviceInfo deviceInfo)
        {
            this._deviceInfo = deviceInfo;
        }
 
        /// <summary>
        /// Scan a image with JPEG Format
        /// </summary>
        /// <returns></returns>
        public ImageFile ScanJPEG()
        {
            // Connect to the device
            var device = this._deviceInfo.Connect();

            var itemsCount = 0;

            itemsCount = device.Items.Count;


            try
            {
                WIA.Item item = device.ExecuteCommand(WIA.CommandID.wiaCommandTakePicture);

                System.Threading.Thread.Sleep(2000);

                WIA.Item itemWia = device.Items[itemsCount + 1];

                WIA.ImageFile imageFileNew = itemWia.Transfer() as WIA.ImageFile;

                device.Items.Remove(itemsCount + 1);

                return imageFileNew;
            }
            catch (COMException e)
            {
                // Display the exception in the console.
                Console.WriteLine(e.ToString());

                uint errorCode = (uint)e.ErrorCode;

                // Catch 2 of the most common exceptions
                if (errorCode == 0x80210006)
                {
                    MessageBox.Show("La camara esta ocupada o no esta lista, intente de nuevo");
                }
                else if (errorCode == 0x80210064)
                {
                    MessageBox.Show("Proceso de toma de foto cancelada, intente de nuevo");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error no controlado, intente de nuevo", "Error", MessageBoxButtons.OK);
                }
            }
            finally
            {
                
            }

            return null;
        }
        
        /// <summary>
        /// Declare the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (string) this._deviceInfo.Properties["Name"].get_Value();
        }

        //TODO: possibly reverse iteration to improve performance
        private bool DeleteItem(WIA.Items items, string itemId)
        {
            for (int x = 1; x <= items.Count; x++)
            {
                if (items[x].ItemID == itemId)
                {
                    items.Remove(x);
                    return true;
                }
                else if (items[x].Items.Count > 0)
                {
                    if (DeleteItem(items[x].Items, itemId))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
