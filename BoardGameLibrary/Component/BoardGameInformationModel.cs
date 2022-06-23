using Microsoft.Extensions.Localization;

namespace BoardGameLibrary.Component
{
    public class BoardGameInformationModel
    {
        public string Title { get; }
        public string Creator { get; }
        public string Description { get; }
        public string ImageTitle { get; }
        public bool DisabledButton { get; }

        private BoardGameInformationModel(string title, string creator, string description, string imageTitle, bool disabledButton)
        {
            Title = title;
            Creator = creator;
            Description = description;
            ImageTitle = imageTitle;
            DisabledButton = disabledButton;
        }

        public static BoardGameInformationModel From(string title, string creator, string description, string imageTitle, bool disabledButton)
            => new(title, creator, description, imageTitle, disabledButton);

        public static BoardGameInformationModel ComingSoon(IStringLocalizer l) 
            => new(l["DefaultBoardGameTitle"], l["DefaultCreator"], l["DefaultInformation"], "Question.png", true);
    }
}
