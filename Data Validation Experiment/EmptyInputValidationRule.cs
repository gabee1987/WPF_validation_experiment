using System.Windows.Controls;

namespace Data_Validation_Experiment
{
    public class EmptyInputValidationRule : ValidationRule
    {
        public override ValidationResult Validate( object value, System.Globalization.CultureInfo cultureInfo )
        {
            if( value == null )
                return new ValidationResult( true, null );

            return new ValidationResult( false, "Please fill out the textbox!" );
        }
    }
}
