namespace Codeparts.Frameplate.Web.Forms
{
    public interface IFormHandlerFactory
	{
        IFormHandler<TForm> Create<TForm>() where TForm : IForm;
	}
}