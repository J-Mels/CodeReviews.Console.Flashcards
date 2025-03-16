using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    class Stack
    {
        // ----------------------------------------------------- FIELDS ----------------------------------------------------- //
        private string _stackName;
        private List<Flashcard> _flashcards = new List<Flashcard>();

        // ----------------------------------------------------- PROPERTIES ----------------------------------------------------- //
        public int StackId { get; } // Omit setter so that StackId can only be set during initialization

        public string StackName
        {
            get { return _stackName; }
            set
            {
                // Checking for null/emnpty values here in addition to the constructor in case StackName property gets directly re-assigned
                if (string.IsNullOrEmpty(value) || value.Length > 100)
                    throw new ArgumentException("Stack name must be non-empty and 100 characters or less");

                _stackName = value;
            }
        }

        public List<Flashcard> Flashcards { get { return _flashcards; } } // Omit setter so users can't pass in a whole new list; Only the current list can be modified via Stack methods

        // ----------------------------------------------------- CONSTRUCTOR ----------------------------------------------------- //
        public Stack(int stackId, string stackName)
        {
            if (string.IsNullOrEmpty(stackName) || stackName.Length > 100)
                throw new ArgumentException("Stack name must be non-empty and 100 characters or less");

            StackId = stackId;
            _stackName = stackName;
        }

        // ----------------------------------------------------- METHODS ----------------------------------------------------- //
        public void AddFlashcard(Flashcard flashcard)
        {
            if (flashcard == null)
                throw new ArgumentNullException("Error: Cannot set flashcard to a null value.");

            if (flashcard.StackId == StackId)
            {
                _flashcards.Add(flashcard);
            }
            else
            {
                throw new ArgumentException("The flashcard's stack ID must match the ID of the stack it is being added to.");
            }
        }

        public void DeleteFlashcard(Flashcard flashcard)
        {
            if (flashcard == null)
                throw new ArgumentNullException("Error: Cannot set flashcard to a null value.");

            if (flashcard.StackId == StackId)
            {
                _flashcards.Remove(flashcard);
            }
            else
            {
                throw new ArgumentException("The flashcard's stack ID must match the ID of the stack it is being deleted from.");
            }
        }
    }
}