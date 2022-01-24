using MLToolkit.Forms.SwipeCardView.Core;
using System.Threading.Tasks;
using Tinder.Models;
using Tinder.ViewModels;
using Xamarin.Forms;

namespace Tinder.Views
{
    public partial class SwiperPage : ContentPage
    {
        private SwiperPageViewModel _vm;

        public SwiperPage()
        {
            InitializeComponent();
            _vm = (SwiperPageViewModel)BindingContext;
        }

        private void SwipeCard_Dragging(object sender, DraggingCardEventArgs e)
        {
            var view = (View)sender;
            var nopeFrame = view.FindByName<Frame>("NopeFrame");
            var likeFrame = view.FindByName<Frame>("LikeFrame");
            var superLikeFrame = view.FindByName<Frame>("SuperLikeFrame");

            switch (e.Position)
            {
                case DraggingCardPosition.Start:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    superLikeFrame.Opacity = 0;
                    break;

                case DraggingCardPosition.OverThreshold:
                    if (e.Direction == SwipeCardDirection.Left)
                    {
                        nopeFrame.Opacity = 1;
                        likeFrame.Opacity = 0;
                        superLikeFrame.Opacity = 0;
                    }
                    else if (e.Direction == SwipeCardDirection.Right)
                    {
                        likeFrame.Opacity = 1;
                        nopeFrame.Opacity = 0;
                        superLikeFrame.Opacity = 0;
                    }
                    else if (e.Direction == SwipeCardDirection.Up)
                    {
                        likeFrame.Opacity = 0;
                        nopeFrame.Opacity = 0;
                        superLikeFrame.Opacity = 1;
                    }

                    break;

                case DraggingCardPosition.FinishedUnderThreshold:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    superLikeFrame.Opacity = 0;
                    break;

                case DraggingCardPosition.FinishedOverThreshold:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    superLikeFrame.Opacity = 0;
                    break;
            }
        }

        private async void SwipeCard_Swiped(object sender, SwipedCardEventArgs e)
        {
            var user = (User)e.Item;
            var isLastUser = _vm.IsLastUser(user);
            _vm.UserSwipped(user);

            if(isLastUser)
            {
                await Task.WhenAll(
                    NopeButton.ScaleTo(0, 500),
                    LikeButton.ScaleTo(0, 500),
                    SuperLikeButton.ScaleTo(0, 500)
                    );   
            }
        }

        private void NopeButton_Clicked(object sender, System.EventArgs e)
        {
            SwipeCard.InvokeSwipe(SwipeCardDirection.Left);
        }

        private void SuperLikeButton_Clicked(object sender, System.EventArgs e)
        {
            SwipeCard.InvokeSwipe(SwipeCardDirection.Up);
        }

        private void LikeButton_Clicked(object sender, System.EventArgs e)
        {
            SwipeCard.InvokeSwipe(SwipeCardDirection.Right);
        }
    }
}
