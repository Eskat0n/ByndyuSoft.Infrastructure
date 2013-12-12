namespace Codeparts.Frameplate.Web
{
    using System;
    using System.Text;
    using System.Web.Mvc;
    using ActionResults;
    using ByndyuSoft.Infrastructure.Domain;
    using Forms;

    public abstract class CommonController : Controller
    {
        private const string ModelStateKey = "ModelState";

        public IFormHandlerFactory FormHandlerFactory { get; set; }

        public IQueryBuilder Query { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sucessResult"></param>
        /// <typeparam name="TForm"></typeparam>
        /// <returns></returns>
        protected ActionResult Form<TForm>(TForm form, ActionResult sucessResult) 
            where TForm : IForm
        {
            return Form(form, () => sucessResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sucessResult"></param>
        /// <param name="failResult"></param>
        /// <typeparam name="TForm"></typeparam>
        /// <returns></returns>
        protected ActionResult Form<TForm>(TForm form, ActionResult sucessResult, ActionResult failResult)
            where TForm : IForm
        {
            return Form(form, () => sucessResult, () => failResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="successResult"></param>
        /// <typeparam name="TForm"></typeparam>
        /// <returns></returns>
        protected ActionResult Form<TForm>(TForm form, Func<ActionResult> successResult)
            where TForm : IForm
        {
            return Form(form, successResult, () => Redirect(Request.UrlReferrer.AbsoluteUri));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="successResult"></param>
        /// <param name="failResult"></param>
        /// <typeparam name="TForm"></typeparam>
        /// <returns></returns>
        protected ActionResult Form<TForm>(TForm form, Func<ActionResult> successResult, Func<ActionResult> failResult)
            where TForm : IForm
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FormHandlerFactory.Create<TForm>().Execute(form);

                    return successResult();
                }
                catch (FormHandlerException fhe)
                {
                    var key = string.IsNullOrEmpty(fhe.Key) ? "form" : fhe.Key;
                    ModelState.AddModelError(key, fhe.Message);
                }
            }

            TempData[ModelStateKey] = ModelState;
            return failResult();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (TempData[ModelStateKey] != null && ModelState.Equals(TempData[ModelStateKey]) == false)
                ModelState.Merge((ModelStateDictionary) TempData[ModelStateKey]);

            base.OnActionExecuted(filterContext);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return new MyJsonResult(data, contentType, contentEncoding);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new MyJsonResult(data, contentType, contentEncoding);
        }
    }
}