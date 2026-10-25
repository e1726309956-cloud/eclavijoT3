namespace eclavijoT3;

public partial class vRegistro : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();

        pkIdentificacion.SelectedItem = null;
        txtNumero.Text = "";
        txtNombres.Text = "";
        txtApellidos.Text = "";
        txtCorreo.Text = "";
        txtSalario.Text = "";
        dtFecha.Date = DateTime.Now;
    }

    public vRegistro()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            string tipo = pkIdentificacion.SelectedItem?.ToString();
            string numero = txtNumero.Text;
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            DateTime fecha = (DateTime)dtFecha.Date;
            string correo = txtCorreo.Text;
            string salarioTexto = txtSalario.Text;

            // VALIDACION DE TIPO IDENTIFICACION
            if (string.IsNullOrWhiteSpace(tipo))
            {
                await DisplayAlert("Error",
                    "Seleccione un tipo de identificación",
                    "Aceptar");
                return;
            }

            // VALIDACION DE NUMERO IDENTIFICACION
            if (string.IsNullOrWhiteSpace(numero))
            {
                await DisplayAlert("Error",
                    "Ingrese la identificación",
                    "Aceptar");
                return;
            }

            // VALIDAR NOMBRES
            if (string.IsNullOrWhiteSpace(nombres))
            {
                await DisplayAlert("Error",
                    "Ingrese los nombres",
                    "Aceptar");
                return;
            }

            // VALIDAR APELLIDOS
            if (string.IsNullOrWhiteSpace(apellidos))
            {
                await DisplayAlert("Error",
                    "Ingrese los apellidos",
                    "Aceptar");
                return;
            }

            // VALIDAR CORREO
            if (string.IsNullOrWhiteSpace(correo))
            {
                await DisplayAlert("Error",
                    "Ingrese el correo",
                    "Aceptar");
                return;
            }

            if (!correo.Contains("@"))
            {
                await DisplayAlert("Error",
                    "Correo inválido",
                    "Aceptar");
                return;
            }

            // VALIDAR SALARIO
            if (string.IsNullOrWhiteSpace(salarioTexto))
            {
                await DisplayAlert("Error",
                    "Ingrese el salario",
                    "Aceptar");
                return;
            }

            if (!double.TryParse(salarioTexto, out double salario))
            {
                await DisplayAlert("Error",
                    "El salario debe ser numérico",
                    "Aceptar");
                return;
            }

            if (salario <= 0)
            {
                await DisplayAlert("Error",
                    "El salario debe ser mayor a cero",
                    "Aceptar");
                return;
            }

            // VALIDAR CI
            if (tipo == "CI")
            {
                if (numero.Length != 10 || !numero.All(char.IsDigit))
                {
                    await DisplayAlert("Error",
                        "La CI debe contener 10 números",
                        "Aceptar");
                    return;
                }
            }

            // VALIDAR RUC
            if (tipo == "RUC")
            {
                if (numero.Length != 13 || !numero.All(char.IsDigit))
                {
                    await DisplayAlert("Error",
                        "El RUC debe contener 13 números",
                        "Aceptar");
                    return;
                }
            }

            await Navigation.PushAsync(
                new vResumen(
                    tipo,
                    numero,
                    nombres,
                    apellidos,
                    fecha,
                    correo,
                    salario));
        }
        catch (Exception ex)
        {
            await DisplayAlert(
                "Error",
                ex.Message,
                "Aceptar");
        }
    }
}