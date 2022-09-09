namespace Proyecto1.DATOS.Repositorios
{
    public interface ICategoriaRepositorio
    {
        List<Categoria> ObtenerTodas();
        void CrearCategoria(Categoria categoria);
        
    }
}
