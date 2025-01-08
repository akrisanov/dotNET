using Microsoft.AspNetCore.Components;

namespace FrontendWebDevForBeginners.Components.Pages
{
    public partial class Counter
    {
        [Parameter]
        public int IncrementAmount { get; set; } = 1;

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount += IncrementAmount;
        }
    }
}
