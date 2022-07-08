using Microsoft.Extensions.Localization;

namespace BoardGameTools.Component
{
    public class BoardGameInformationModel
    {
        public int Id { get; }
        public string Title { get; }
        public string Creator { get; }
        public string Description { get; }
        public string ImageTitle { get; }
        public bool DisabledButton { get; }

        private BoardGameInformationModel(int id, string title, string creator, string description, string imageTitle, bool disabledButton)
        {
            Id = id;
            Title = title;
            Creator = creator;
            Description = description;
            ImageTitle = imageTitle;
            DisabledButton = disabledButton;
        }

        public static BoardGameInformationModel From(int id, string title, string creator, string description, string imageTitle, bool disabledButton)
            => new(id, title, creator, description, imageTitle, disabledButton);

        public static BoardGameInformationModel ComingSoon(IStringLocalizer l) 
            => new(-1, l["DefaultBoardGameTitle"], l["DefaultCreator"], l["DefaultInformation"], "Question.png", true);
    }
}
