﻿using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Controls.Notification;
using Syncfusion.Windows.Shared;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace HubTile_Getting_Started
{
    /// <summary>
    /// Class represents the behaviour or business logic for MainWindow.xaml
    /// </summary>
    class ViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the command for window Loaded.
        /// </summary>
        private ICommand windowLoaded;

        /// <summary>
        /// Maintains the command for hubtile loaded.
        /// </summary>
        private ICommand hubTileLoaded;

        /// <summary>
        /// Maintains the command for transition loaded.
        /// </summary>
        private ICommand transition;

        /// <summary>
        /// Maintains the transition.
        /// </summary>
        private string selectedTransition;

        /// <summary>
        /// Mailtains the hubTile transition colection.
        /// </summary>
        private HubTileTransitionCollection hubTileTransitionCollectionProperty;

        /// <summary>
        /// Maintains the timeSpanInterval.
        /// </summary>
        private TimeSpan timeSpanInterval;

        /// <summary>
        /// Maintains the collection for hubTile transition.
        /// </summary>
        private HubTileTransitionCollection collection = new HubTileTransitionCollection();

        /// <summary>
        /// Maintains the collection for slide transition.
        /// </summary>
        private SlideTransition slideTransition = new SlideTransition();


        /// <summary>
        /// Maintains the collection for fade transition.
        /// </summary>
        private FadeTransition fadeTransition = new FadeTransition();

        /// <summary>
        /// Gets or sets the timeSpanInterval command <see cref="ViewModel"/> class.
        /// </summary>
        public TimeSpan TimeSpanInterval
        {
            get
            {
                return timeSpanInterval;
            }
            set
            {
                timeSpanInterval = value;
                RaisePropertyChanged("TimeSpanInterval");
            }
        }

        /// <summary>
        /// Gets or sets the command for window loaded <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand WindowLoaded
        {
            get
            {
                return windowLoaded;
            }
        }

        /// <summary>
        /// Maintains the hubTileTransition collection <see cref="ViewModel"/> class.
        /// </summary>
        public HubTileTransitionCollection HubTileTransitionCollectionProperty
        {
            get
            {
                return hubTileTransitionCollectionProperty;
            }
            set
            {
                hubTileTransitionCollectionProperty = value;
                RaisePropertyChanged("HubTileTransitionCollectionProperty");
            }
        }
        /// <summary>
        /// Gets or sets the selectedTransition <see cref="ViewModel"/> class.
        /// </summary>
        public string SelectedTransition
        {
            get
            {
                return selectedTransition;
            }
            set
            {
                selectedTransition = value;
                RaisePropertyChanged("SelectedTransition");
            }
        }

        /// <summary>
        /// Gets or sets the command for hubtile loaded <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand HubTileLoaded
        {
            get
            {
                return hubTileLoaded;
            }
        }

        /// <summary>
        /// Gets or sets the command for transition 
        /// </summary>
        public ICommand Transition
        {
            get
            {
                return transition;
            }
        }

        /// <summary>
        /// Initialize the new instance of <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            windowLoaded = new DelegateCommand<object>(ExecuteWindowLoaded);
            hubTileLoaded = new DelegateCommand<object>(ExecuteHubTileLoaded);
            transition = new DelegateCommand<object>(ExecuteTransition);
        }

        /// <summary>
        /// Method used to execute the window loaded command. 
        /// </summary>
        /// <param name="parameter">Specifies the object parameter</param>
        public void ExecuteWindowLoaded(object parameter)
        {
            TimeSpanInterval = TimeSpan.FromSeconds(3.0);
        }

        /// <summary>
        /// Method used to execute the hubtile loaded command. 
        /// </summary>
        /// <param name="parameter">Specifies the object parameter</param>
        public void ExecuteHubTileLoaded(object parameter)
        {
            if (SelectedTransition == "FadeTransition")
            {
                if (collection.Contains(slideTransition))
                    collection.Remove(slideTransition);

                collection.Add(fadeTransition);
            }
            else
            {
                if (collection.Contains(fadeTransition))
                    collection.Remove(fadeTransition);

                collection.Add(slideTransition);
            }
			
            HubTileTransitionCollectionProperty = collection;
        }

        /// <summary>
        /// Method used to execute the transition command. 
        /// </summary>
        /// <param name="parameter">Specifies the object parameter</param>
        public void ExecuteTransition(object parameter)
        {
            if (SelectedTransition == "FadeTransition")
            {
                if (collection.Contains(slideTransition))
                    collection.Remove(slideTransition);

                collection.Add(fadeTransition);
            }
            else
            {
                if (collection.Contains(fadeTransition))
                    collection.Remove(fadeTransition);

                collection.Add(slideTransition);
            }
        }
    }
}

