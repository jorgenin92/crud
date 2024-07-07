namespace Invent.Model
{
    public class Inventario
    {
        public int id_prod { get; set; }
        public string id_mcodbarra { get; set; }
        public string plu { get; set; }
        public string descripcion { get; set; }
        public int boleta { get; set; }
        public string ubicacion { get; set; }
        public double monto { get; set; }
        public double cantidad { get; set; }
        public double valor { get; set; }
        public double total { get; set; }
        public double valor_imp { get; set; }
        public double total_imp { get; set; }
        public int id_unico { get; set; }
        public DateTime fecha { get; set; }
        public Int16 numeracion { get; set; }

        public Inventario(int id_prod_, string id_mcodbarra_, string plu_, string descripcion_, int boleta_, string ubicacion_, double monto_, double cantidad_, double valor_, double total_, double valor_imp_, double total_imp_, int id_unico_, DateTime fecha_, short numeracion)
        {
            this.id_prod = id_prod_;
            this.id_mcodbarra = id_mcodbarra_;
            this.plu = plu_;
            this.descripcion = descripcion_;
            this.boleta = boleta_;
            this.ubicacion = ubicacion_;
            this.monto = monto_;
            this.cantidad = cantidad_;
            this.valor = valor_;
            this.total = total_;
            this.valor_imp = valor_imp_;
            this.total_imp = total_imp_;
            this.id_unico = id_unico_;
            this.fecha = fecha_;
            this.numeracion = numeracion;
        }

        public Inventario()
        {
            this.id_prod = 0;
            this.id_mcodbarra = "";
            this.plu = "";
            this.descripcion = "";
            this.boleta = 0;
            this.ubicacion = "";
            this.monto = 0;
            this.cantidad = 0;
            this.valor = 0;
            this.total = 0;
            this.valor_imp = 0;
            this.total_imp = 0;
            this.id_unico = 0;
            this.fecha = DateTime.MinValue;
            this.numeracion = 0;
        }
    }
}