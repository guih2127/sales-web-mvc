using System;

namespace SalesWebMVC.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; }
        // Adicionamos esse campo caso queiramos mandar uma mensagem personalizada na p�gina de erro.

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}