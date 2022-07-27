using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using FlickrApp.Commands;
using FlickrApp.Model;
using FlickrApp.Utility;

namespace FlickrApp.ViewModel
{
    public class ImageSourceViewModel 
    {
        


        private ObservableCollection<ImageSourceInfo> imageList = new ObservableCollection<ImageSourceInfo>();
        public ObservableCollection<ImageSourceInfo> ImageList
        {
            get { return imageList; }
            set
            {
                imageList = value;
            }
        }

        private ICommand showCommand;
        public ICommand ShowCommand
        {
            get
            {
                if (showCommand == null)
                    showCommand = new RelayCommand(ShowImagesOnUI);
                return showCommand;
            }
        }

        private async void ShowImagesOnUI(object parameter)
        {
            string SearchWord = (string)parameter;
            ImageList.Clear();
            if(string.IsNullOrEmpty(SearchWord))
            {
                MessageBox.Show("Please enter a search word and then click on Search");
                return;
            }

            //get tweets for the search  word
            string tweets = await Utility.TwitterUtility.GetTweets(SearchWord);

            //Get all the Image URLs to show in the UI
            var ImageURLList = new FlickrUtility().getFlickrXMLForSearchWord(SearchWord);
            foreach (var ImageURL in ImageURLList)
            {
                ImageList.Add(new ImageSourceInfo(new BitmapImage(ImageURL), tweets));
            }
        }

    }

}
