namespace BarnManagement.Business.Constants
{
    public class Messages
    {
            public static class Info
            {
                public const string OperationSuccess = "Operation completed successfully.";
                public const string LoginSuccess = "Login successful";
                public const string BarnCreated = "Barn created successfully";
                public const string AnimalsPurchased = "Animals purchased";
                public const string UserCreated = "User created successfully.";
                public const string BarnCreatedLog = "New barn created";
                public const string AnimalsGrewUp = "{0} animals grew up and are ready for production.";
        }

            public static class Error
            {
                public const string GeneralError = "An unexpected error. Please check logs.";
                public const string DbConnectionError = "Database connection failed.";
                public const string InsufficientBalance = "Insufficient balance";
                public const string InvalidInput = "Fill in all fields.";
                public const string LoginFailed = "Invalid username or password.";
                public const string UserAlreadyExists = "This username is already taken.";
                public const string CapacityExceeded = "Barn capacity exceeded. Cannot add more animals.";
                public const string RegistrationFailed = "User registration failed:";
                public const string DataLoadError = "Error loading data:";
                public const string BarnCreationError = "Error creating barn.";
                public const string PageLoadError = "Page could not be loaded: {0}";
                public const string TimerError = "Aging Timer Error: {0}";
                public const string BarnNotFound = "Barn information could not be found.";
        }

            public static class Warning
            {
                public const string LowBalance = "Warning: Barn balance is running low.";
                public const string AreYouSure = "Are you sure you want to proceed?";
                public const string SelectSpecies = "Please select an animal species.";
                public const string EnterAnimalName = "Please enter a name for the animal.";
                public const string SelectGender = "Please select a gender.";
            }

            public static class Titles
            {
                public const string Error = "Error";
                public const string Warning = "Warning";
                public const string Info = "Information";
                public const string Success = "Success";
            }
        
    }
}
