namespace eclavijoT3;

using System.IO;
public partial class vResumen : ContentPage
{
    string informacion;

    public vResumen(
        string tipo,
        string numero,
        string nombres,
        string apellidos,
        DateTime fecha,
        string correo,
        double salario)
    {
        InitializeComponent();

        double iess = salario * 0.0945;

        lblTipo.Text =
            "Tipo: " + tipo;

        lblNumero.Text =
            "Identificación: " + numero;

        lblNombres.Text =
            "Nombres: " + nombres;

        lblApellidos.Text =
            "Apellidos: " + apellidos;

        lblFecha.Text =
            "Fecha: " + fecha.ToShortDateString();

        lblCorreo.Text =
            "Correo: " + correo;

        lblSalario.Text =
            "Salario: $" + salario;

        lblIess.Text =
            "Aporte IESS: $" +
            iess.ToString("0.00");

        informacion =
            $"Tipo: {tipo}\n" +
            $"Identificación: {numero}\n" +
            $"Nombres: {nombres}\n" +
            $"Apellidos: {apellidos}\n" +
            $"Fecha: {fecha}\n" +
            $"Correo: {correo}\n" +
            $"Salario: {salario}\n" +
            $"IESS: {iess}";
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            string contenido =
                lblTipo.Text + "\n" +
                lblNumero.Text + "\n" +
                lblNombres.Text + "\n" +
                lblApellidos.Text + "\n" +
                lblFecha.Text + "\n" +
                lblCorreo.Text + "\n" +
                lblSalario.Text + "\n" +
                lblIess.Text;

            string escritorio = Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop);

            string ruta = Path.Combine(
                escritorio,
                "contacto.txt");

            File.WriteAllText(ruta, contenido);

            await DisplayAlert(
                "Éxito",
                "Archivo guardado en el escritorio",
                "Aceptar");
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