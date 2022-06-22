using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BoardGameLibrary.Component
{
    public class BoardGameCardBase : ComponentBase
    {
        [Inject]
        private IStringLocalizer<App>? Localization { get; set; }

        protected List<BoardGameInformationModel> _boardGameInformations = new();
        protected int _mdMudItem = 4;

        protected override void OnInitialized()
        {
            if (Localization is null)
                throw new ArgumentNullException();

            _boardGameInformations = new List<BoardGameInformationModel>
            {
                BoardGameInformationModel.From("Mage Knight", "Vlaada Chvatil", Localization["MageKnightInformation"], "MageKnightCard.png", false),
                BoardGameInformationModel.ComingSoon(Localization)
            };

            _mdMudItem = _boardGameInformations.Count switch
            {
                1 => 4,
                2 => 2,
                _ => 4
            };
        }
    }
}
