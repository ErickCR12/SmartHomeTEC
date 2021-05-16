using Aspose.Pdf.Text;
using API_Service.Models;
using System;
using System.IO;
using Aspose.Pdf;
using Spire.Email;
using Spire.Email.Smtp;
using Spire.Email.IMap;

namespace API_Service.Docs
{
    public static class DocSender
    {
        public static void MakeBillDocument(Order order)
        {
            string path = Environment.CurrentDirectory + "\\Docs";
            // Initialize document object
            Document document = new Document();
            // Add page
            Page page = document.Pages.Add();

            // -----------------------------------------------------------s--
            // Add Header
            var header = new TextFragment("Factura de compra | Disp. " + order.device_serial_number);
            header.TextState.Font = FontRepository.FindFont("Arial");
            header.TextState.FontSize = 24;
            header.HorizontalAlignment = HorizontalAlignment.Center;
            header.Position = new Position(130, 720);
            page.Paragraphs.Add(header);

            // Add description
            var billContentText = "\n\nNumero de factura: " + order.bill_number;
            billContentText += "\n\nFecha de la compra: " + order.purchase_date.ToString("yyyy/MM/dd");
            billContentText += "\n\nTipo de dispositivo: " + order.device.device_type_name;
            billContentText += "\n\nPrecio: " + order.price;
            var billContent = new TextFragment(billContentText);
            billContent.TextState.Font = FontRepository.FindFont("Times New Roman");
            billContent.TextState.FontSize = 14;
            billContent.HorizontalAlignment = HorizontalAlignment.Left;
            page.Paragraphs.Add(billContent);


            document.Save(System.IO.Path.Combine(path, "Bill" + order.bill_number + ".pdf"));

        }

        public static void MakeWarrantyDocument(Order order)
        {
            string path = Environment.CurrentDirectory + "\\Docs";
            // Initialize document object
            Document document = new Document();
            // Add page
            Page page = document.Pages.Add();

            // -------------------------------------------------------------
            // Add Header
            var header = new TextFragment("Garantía | Disp. " + order.device_serial_number);
            header.TextState.Font = FontRepository.FindFont("Arial");
            header.TextState.FontSize = 24;
            header.HorizontalAlignment = HorizontalAlignment.Center;
            header.Position = new Position(130, 720);
            page.Paragraphs.Add(header);

            // Add description
            var WarrantyContentText = "\n\nFecha de la compra: " + order.purchase_date.ToString("yyyy/MM/dd"); ;
            WarrantyContentText += "\n\nFecha de terminación de garantía: " + DateTime.Today.AddMonths(order.device.device_type.warranty_months).ToString("yyyy/MM/dd"); ;
            WarrantyContentText += "\n\nCliente que realizó compra: " + order.client.name + " " + order.client.last_name1 + " " + order.client.last_name2;
            WarrantyContentText += "\n\nTipo de dispositivo: " + order.device.device_type_name;
            WarrantyContentText += "\n\nMarca: " + order.device.brand;
            var WarrantyContent = new TextFragment(WarrantyContentText);
            WarrantyContent.TextState.Font = FontRepository.FindFont("Times New Roman");
            WarrantyContent.TextState.FontSize = 14;
            WarrantyContent.HorizontalAlignment = HorizontalAlignment.Left;
            page.Paragraphs.Add(WarrantyContent);


            document.Save(System.IO.Path.Combine(path, "Warranty" + order.bill_number + ".pdf"));

        }

        public static void SendOrderInfo(Order order){
            MakeBillDocument(order);
            MakeWarrantyDocument(order);

            MailAddress addressFrom = "officialsmarthometec@gmail.com";
	        MailAddress addressTo = order.client_email;

            MailMessage message = new MailMessage(addressFrom, addressTo);

            message.Subject = "Confirmación de compra para dispositivo " + order.device_serial_number;
            message.BodyText = "Hola " + order.client.name + "!\r\n"+
            "Adjuntos se encuentran los documentos con la factura y garantía de su nuevo dispositivo\r\n" +
            "Gracias por escogernos!";

	        message.Date = DateTime.Now;

            string path = Environment.CurrentDirectory + "\\Docs";
            message.Attachments.Add(new Attachment(System.IO.Path.Combine(path, "Bill" + order.bill_number + ".pdf")));
            message.Attachments.Add(new Attachment(System.IO.Path.Combine(path, "Warranty" + order.bill_number + ".pdf")));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.ConnectionProtocols = ConnectionProtocols.Ssl;
            smtp.Username = addressFrom.Address;
            smtp.Password = "Sm@rtHomeBD2021";
            smtp.Port = 587;

            smtp.SendOne(message);
        }
    }
}
