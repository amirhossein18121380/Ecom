using FluentValidation;


namespace Common.FluentValidation
{
    public class ValidatonTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                //throw new ValidationException(result.Errors);
            }
        }
    }
}
