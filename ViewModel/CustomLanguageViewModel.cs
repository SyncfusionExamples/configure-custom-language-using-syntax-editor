﻿using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SyntaxEditor_CustomLanguage
{
    /// <summary>
    /// Represents the view model class for edit control
    /// </summary>
    public class CustomLanguageViewModel:NotificationObject
    {
        /// <summary>
        /// Maintains the document source of the edit control
        /// </summary>
        private string documentSource;

        /// <summary>
        /// Maintains the loaded command for edit control
        /// </summary>
        private ICommand editLoadedCommand;

        /// <summary>
        /// Maintains the language of the edit control
        /// </summary>
        private Languages language;

        /// <summary>
        /// Maintains the font family of the content in edit control
        /// </summary>
        private FontFamily selectedFont;

        /// <summary>
        /// Initializes the instance of <see cref="CustomLanguageViewModel"/>class
        /// </summary>
        public CustomLanguageViewModel()
        {
            DocumentSource = @"Data\syntaxeditor\PythonSource.py";
            SelectedFont = new FontFamily("Verdana");
            Language = Languages.Custom;
            editLoadedCommand = new DelegateCommand<object>(ExecuteEditLoaded);
        }
        
        /// <summary>
        /// Gets or sets the loaded command for edit control
        /// </summary>
        public ICommand EditLoadedCommand
        {
            get
            {
                return editLoadedCommand;
            }
        }

        /// <summary>
        /// Gets or sets the font family of the content in edit control
        /// </summary>
        public FontFamily SelectedFont
        {
            get
            {
                return selectedFont;
            }
            set
            {
                selectedFont = value;
                RaisePropertyChanged("SelectedFont");
            }
        }

        /// <summary>
        /// Gets or sets the language of the content in edit control
        /// </summary>
        public Languages Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
                RaisePropertyChanged("Language");
            }
        }

        /// <summary>
        /// Gets or sets the document source of the edit control
        /// </summary>
        public string DocumentSource
        {
            get
            {
                return documentSource;
            }
            set
            {
                documentSource = value;
                RaisePropertyChanged("DocumentSource");
            }
        }
        
        /// <summary>
        /// Method to execute edit control loaded
        /// </summary>
        /// <param name="obj">Specifies the object parameter</param>
        private void ExecuteEditLoaded(object obj)
        {
            MainWindow custom = new MainWindow();
            PythonLanguage customLanguage = new PythonLanguage(obj as EditControl);
            customLanguage.Lexem = custom.Resources["pythonLanguageLexems"] as LexemCollection;
            customLanguage.Formats = custom.Resources["pythonLanguageFormats"] as FormatsCollection;
            (obj as EditControl).CustomLanguage = customLanguage;
        }
    }
}
