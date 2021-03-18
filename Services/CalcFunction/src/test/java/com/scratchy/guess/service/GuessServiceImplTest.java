package com.scratchy.guess.service;

import com.scratchy.guess.model.Guess;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class GuessServiceImplTest {

    @Test
    void getGuessVarianceValue() {

        int actualValue = 7;
        int guessValue = 6;

        GuessServiceImpl guessService = new GuessServiceImpl();
        var difference = guessService.getGuessDifferenceFromActualValue(actualValue, guessValue);

        assertEquals(1, difference);
    }

    @Test
    void updateGuessWithVarianceValue() {
        Guess guess = new Guess();
        guess.setPlayerId(1);
        guess.setGuessValue(6);
        int difference = 7;

        GuessServiceImpl guessService = new GuessServiceImpl();
        var newGuess = guessService.updateGuessWithVarianceValue(guess, difference);

        assertNotNull(newGuess);
        assertEquals(difference, newGuess.getOverUnderValue());
        assertEquals(guess.getPlayerId(), newGuess.getPlayerId());
        assertEquals(guess.getGuessValue(), newGuess.getGuessValue());
    }
}