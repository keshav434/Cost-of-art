
namespace SimonsShapes
{

    public static class ConstStrings
    {
        /*
         * 
         * This class contains constant strings to help ensure that the output of your program
         * matches with the expected output for automated testing purposes.
         * Below are some examples of how to use these strings elsewhere in your code.
         * 
         * Console.WriteLine(ConstStrings.YES_OR_NO);
         * Console.WriteLine(INVALID_ANSWER, answer);
         * Console.WriteLine(ConstStrings.VALUE_MIN_MAX, min, max);
         * 
         * or
         * 
         * string myString = String.Format(ConstStrings.VALUE_MIN_MAX, min, max);
         * 
         * For more information see Composite Formatting
         * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/
         * 
         * You may find you need to edit some of these strings
         * or add additional strings
         */

        public const string SELECT_ACTION = "Please select an action.";
        public const string CREATE_PAINTING = "Create new painting.";
        public const string LOAD_PAINTING = "Load painting from file.";
        public const string VALUE_MIN_MAX = "Please enter a value from {0} to {1} inclusive.";
        public const string NOT_IN_RANGE = "{0} is not a value from {1} to {2} inclusive.";
        public const string YES_OR_NO = "Please answer Y or y for yes, or N or n for no.";
        public const string INVALID_ANSWER = "{0} is not a valid answer.";
        public const string NOT_WHOLE_NUMBER = "{0} is not a whole number.";
        public const string NOT_NUMBER = "{0} is not a number.";
        public const string FILE_NOT_FOUND = "File {0} not found.";
        public const string FILE_INCORRECT_FORMAT = "File {0} in incorrect format.";
        public const string NO_PAINT = "{0} cannot supply all the paint you need.";
        public const string EXIT = "Press any key to exit.";
        public const string ENTER_TITLE = "Please enter the title of your painting.";
        public const string INVALID_TITLE = "{0} is not a valid title. A title must be at least 4 characters long after leading and trailing whitespace is removed.";
        public const string SELECT_FILE = "Please select a file.";
        public const string CHANGE_FILL_COLOUR = "Change fill colour.";
        public const string CHANGE_OUTLINE_COLOUR = "Change outline colour.";
        public const string CHANGE_OUTLINE_THICKNESS = "Change outline thickness.";
        public const string SELECT_NEW_FILL_COLOUR = "Please select the new fill colour.";
        public const string SELECT_NEW_OUTLINE_COLOUR = "Please select the new outline colour.";
        public const string SELECT_NEW_OUTLINE_THICKNESS = "Please enter the new outline thickness.";
        public const string ENTER_NEW_RADIUS = "Please enter the circle's new radius.";
        public const string OUTPUT_CIRCLE = "{0} circle with a radius of {1}cm and a {2}cm thick {3} outline.";
        public const string ENTER_NEW_SIDE = "Please enter the triangle's new side.";
        public const string OUTPUT_TRIANGLE = "{0} triangle with a side length of {1}cm and a {2}cm thick {3} outline.";
        public const string ENTER_NEW_SQUARE_HEIGHT = "Please enter the square's new height.";
        public const string OUTPUT_SQUARE = "{0} square with a height of {1}cm and a {2}cm thick {3} outline.";
        public const string ENTER_NEW_RECT_WIDTH = "Please enter the rectangle's new width.";
        public const string ENTER_NEW_RECT_HEIGHT = "Please enter the rectangle's new height.";


    }
}
