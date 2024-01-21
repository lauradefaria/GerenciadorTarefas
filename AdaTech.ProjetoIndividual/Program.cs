using AdaTech.ProjetoIndividual.Models.Business.DataBusiness;

namespace AdaTech.ProjetoIndividual
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            UsuariosData.CarregarUsuariosAtivos();
            TarefasData.CarregarTarefas();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaLogin());
        }
    }
}