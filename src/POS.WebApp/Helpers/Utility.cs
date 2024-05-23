using IronBarCode;

namespace POS.WebApp.Helpers;

public class Utility
{
    public static void GenerateBarcode(string value, string path)
    {
        var myBarcode = BarcodeWriter.CreateBarcode(value, BarcodeWriterEncoding.Code128);
        myBarcode.SaveAsPng(path);
    }
}
