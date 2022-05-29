using FluentValidation.Resources;

namespace EF_NetCore_052022.Validators
{
    public class CustomLanguageManager : LanguageManager
    {
        public CustomLanguageManager()
        {
            AddTranslation("en", "NotNullValidator", "'{PropertyName}' is required.");
            AddTranslation("en-US", "NotNullValidator", "'{PropertyName}' is required.");
            AddTranslation("en-GB", "NotNullValidator", "'{PropertyName}' is required.");
            AddTranslation("vn", "NotNullValidator", "'{PropertyName}' không được null");
            AddTranslation("vn", "NotEmptyValidator", "'{PropertyName}' không được rỗng");
        }
    }
}
