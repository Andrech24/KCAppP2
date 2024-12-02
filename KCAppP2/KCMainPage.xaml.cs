using System;
using Microsoft.Maui.Controls;

namespace KCAppP2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Agregar opciones a los Pickers
            KCPickerOrigen.Items.Add("Metros/segundo");
            KCPickerOrigen.Items.Add("Kilómetros/hora");
            KCPickerOrigen.Items.Add("Millas/hora");

            KCPickerDestino.Items.Add("Metros/segundo");
            KCPickerDestino.Items.Add("Kilómetros/hora");
            KCPickerDestino.Items.Add("Millas/hora");
        }

        // Evento para el botón Convertir
        private void OnConvertirClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(KCEntryCantidad.Text, out double cantidad))
            {
                DisplayAlert("Error", "Por favor, ingresa un valor numérico válido.", "OK");
                return;
            }

            var unidadOrigen = KCPickerOrigen.SelectedItem?.ToString();
            var unidadDestino = KCPickerDestino.SelectedItem?.ToString();

            if (unidadOrigen == null || unidadDestino == null)
            {
                DisplayAlert("Error", "Selecciona ambas unidades de medida.", "OK");
                return;
            }

            double resultado = ConvertirVelocidad(cantidad, unidadOrigen, unidadDestino);
            KCLabelResultado.Text = $"Resultado: {resultado:F2} {unidadDestino}";
        }

        // Método para realizar la conversión de unidades
        private double ConvertirVelocidad(double cantidad, string origen, string destino)
        {
            // Convertir la cantidad a metros por segundo primero
            double valorEnMetrosPorSegundo = origen switch
            {
                "Metros/segundo" => cantidad,
                "Kilómetros/hora" => cantidad / 3.6,
                "Millas/hora" => cantidad * 0.44704,
                _ => throw new ArgumentException("Unidad de origen no válida")
            };

            // Convertir de metros por segundo a la unidad destino
            return destino switch
            {
                "Metros/segundo" => valorEnMetrosPorSegundo,
                "Kilómetros/hora" => valorEnMetrosPorSegundo * 3.6,
                "Millas/hora" => valorEnMetrosPorSegundo / 0.44704,
                _ => throw new ArgumentException("Unidad de destino no válida")
            };
        }

        // Evento para el botón Limpiar
        private void OnLimpiarClicked(object sender, EventArgs e)
        {
            KCEntryCantidad.Text = string.Empty;
            KCPickerOrigen.SelectedItem = null;
            KCPickerDestino.SelectedItem = null;
            KCLabelResultado.Text = "Resultado:";
        }
    }
}
