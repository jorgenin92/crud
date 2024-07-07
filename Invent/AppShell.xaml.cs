namespace Invent
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("InventDetails", typeof(InventDetails));
        }
    }
}
