using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCrystal.CrystalHeart.Helpers.Collections.List;

internal static class PossibleAnswers
{
    internal static readonly List<string> neutralAnswers = new()
    {
        "Так", "Ні", "Можливо", "Швидше за все так", "Швидше за все ні"
    };
    internal static readonly List<string> jokingAnswers = new()
    {
        "Ну, як карта ляже", "Ну а як інакше?", "Так, але тільки якщо ти в шкарпетках з динозаврами", "Ні, тому що я так вирішив",
        ""
    };
    internal static readonly List<string> angryAnswers = new()
    {
        "Так, але ти пошкодуєш","Ні. І навіть не мрій","Ні. Кристал втомився від твоїх дурниць","Так. Кристал сміється з тебе",
        "Можливо, але кристал не вірить у тебе"
    };
}
