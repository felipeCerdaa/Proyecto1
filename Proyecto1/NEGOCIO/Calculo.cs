namespace Proyecto1.NEGOCIO
{
    public class Calculo : Icalculo
    {
        public int Operacion(int num1, int num2)
        {
            var resultado = num1 + num2;
            return resultado;
        }
    }
}
