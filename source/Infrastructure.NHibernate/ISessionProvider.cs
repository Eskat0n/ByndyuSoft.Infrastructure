namespace Codeparts.Frameplate.NHibernate
{
    using global::NHibernate;

    ///<summary>
    ///</summary>
    public interface ISessionProvider
    {
        ///<summary>
        ///</summary>
        ///<returns> </returns>
        ISession CurrentSession { get; }
    }
}