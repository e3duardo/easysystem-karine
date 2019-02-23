namespace Library.Classes
{
    public class QItem
    {
        public string Campo { get; set; }
        public object Objeto { get; set; }


        public QItem(string campo, object valor)
        {
            this.Campo = campo;
            this.Objeto = valor;
        }
    }
}
