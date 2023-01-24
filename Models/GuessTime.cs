using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMLinkedInAttempt57.Models
{


    [Table("Guesses")]
    public class Guess
    {

        [Key]
        public int Id { get; set; }

        public string playerGuess { get; set; }

        public ICollection<GuessTime> GuessTimes { get; set; }

    }

    [Table("GuessTimes")]
    public class GuessTime
    {
        [Key]

        public int Id { get; set; }
        [ForeignKey("Guess")]
        public int FKGuessId { get; set; }
        public DateTime TimeOfGuess { get; set; }

        public Guess Guess { get; set; }
    }
}
