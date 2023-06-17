namespace HerenciaYPolimorfismo.Formas
{
    public interface IForma : IPerimetro, IArea
    {
        string Nombre { get; }
    }
}
