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
                public const string AnimalsGrewUp = "{0} animals ready for production";
                public const string AnimalsDied = "{0} animals died";
                public const string ProductionCycleAccumulated = "Production cycle accumulated";
                public const string ProductionCollectCompleted = "Production collect completed";
                public const string SalesExportSuccess = "Sales history exported successfully.";
                public const string ExportSalesTitle = "Export Sales History (JSON)";
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
                public const string AgingServiceError = "Aging Service Error: {0}";
                public const string BarnNotFound = "Barn information could not be found.";
                public const string ProductionGetPotentialFailed = "GetProductionPotential failed";
                public const string ProductionProduceFailed = "Produce failed";
                public const string ProductionGetAccumulatedFailed = "GetAccumulatedProducts failed";
                public const string ProductionCollectFailed = "CollectManualProductsAsync failed";
                public const string NotEnoughStock = "Not enough stock.";
        }
    

            public static class Warning
            {
                public const string LowBalance = "Warning: Barn balance is running low";
                public const string AreYouSure = "Are you sure you want to proceed?";
                public const string SelectSpecies = "Please select an animal species";
                public const string EnterAnimalName = "Please enter a name for the animal";
                public const string SelectGender = "Please select a gender";
                public const string NoProducibleAnimals = "No producible animals found";
                public const string NoActiveProductsForSpecies = "No active products found for producible species.";
                public const string CollectCalledWithEmptyList = "Collect called with empty list";
                public const string InvalidQuantity = "Invalid quantity";
                public const string NoStockToSell = "No stock to sell";
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
