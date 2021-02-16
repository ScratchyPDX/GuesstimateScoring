package com.scratchy.guess.service;

import com.scratchy.guess.model.Guess;

import java.util.ArrayList;

public interface GuessService {
    public Integer calculateVariance(Integer guessValue, Integer actualValue);
    public ArrayList<Guess> calculateVariances(ArrayList<Guess> guesses, int actualValue);
}
