
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Coffee_Roaster
{
    public sealed partial class Ratings : UserControl, INotifyPropertyChanged
    {

        

        int mRating = -1;
        List<Image> images = new List<Image>();

        BitmapImage goldStar = new BitmapImage()
        {
            UriSource = new Uri("ms-appx:///Assets/goldstar.jpg", UriKind.Absolute)
        };
        BitmapImage greyStar = new BitmapImage()
        {
            UriSource = new Uri("ms-appx:///Assets/Greystar.gif", UriKind.Absolute)
        };



        public Ratings()
        {
            this.InitializeComponent();
            //DataContext = this;
            (this.Content as FrameworkElement).DataContext = this;

            images.Add(img1);
            images.Add(img2);
            images.Add(img3);
            images.Add(img4);
            images.Add(img5);

            MarkRatingSelected(mRating);
        }

        public int Rating
        {
            get
            {
                return (int)GetValue(RatingProperty);
            
                //return mRating.ToString();
            }
            set
            {
                SetValueDp(RatingProperty, value);
                //
                mRating = value;
                MarkRatingSelected(mRating);

                NotifyPropertyChanged("Rating");
            }
        }

        ////Denna propertydefinition behövs för att databindning ska funka från en annan kontroll
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register("Rating", typeof(int),
                typeof(Ratings), null);

        public event PropertyChangedEventHandler PropertyChanged;
        void SetValueDp(DependencyProperty property, object value,
            [System.Runtime.CompilerServices.CallerMemberName] string p = null)
        {
            SetValue(property, value);

            mRating = (int)value;
            MarkRatingSelected(mRating);

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        private void MarkRatingSelected(int index)
        {
            for(int i = 0; i<5; i++)
            {
                if (i <= index)
                    images[i].Source = goldStar;
                else
                    images[i].Source = greyStar;
            }
        }
        
        private void img_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            MarkRatingSelected( images.IndexOf((Image)e.OriginalSource));

        }

        private void img_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            mRating = images.IndexOf((Image)e.OriginalSource);
            MarkRatingSelected(mRating);
        }

        private void UserControl_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            MarkRatingSelected(mRating);
        }
    }
    
}
