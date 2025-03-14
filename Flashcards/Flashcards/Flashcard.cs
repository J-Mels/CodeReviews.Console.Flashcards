using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    public class Flashcard
    {
        private int _flashcardId;
        private int _stackId;
        private string _question;
        private string _answer;

        public int FlashcardId { get => _flashcardId; private set => _flashcardId = value; }
        public int StackId { get => _stackId; private set => _stackId = value; }
        public string Question { get => _question; } // Omitting setter for now as it may make the 1-based ID renumbering more challenging; consider changing later if needed
        public string Answer { get => _answer; } // Omitting setter for now as it may make the 1-based ID renumbering more challenging; consider changing later if needed
        public Flashcard(int flashcardId, int stackId, string question, string answer)
        {
            if (string.IsNullOrWhiteSpace(question) || question.Length > 255)
                throw new ArgumentException("Question must be non-empty and 255 characters or less");
            if (string.IsNullOrWhiteSpace(answer) || answer.Length > 255)
                throw new ArgumentException("Answer must be non-empty and 255 characters or less");

            _flashcardId = flashcardId;
            _stackId = stackId;
            _question = question;
            _answer = answer;

        }
    }
}


// NOTES

// Later, could extend the console menu to offer "Edit Flashcard" as a delete-then-create operation behind the scenes, keeping the class immutable.
