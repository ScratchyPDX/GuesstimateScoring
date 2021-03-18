package com.scratchypdx.guesstimate.calculatevariance.service;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.scratchypdx.guesstimate.calculatevariance.model.Guess;
import java.util.ArrayList;

public interface CalculateService {

    public Integer calculateVariance(Integer guessValue, Integer actualValue);
    public ArrayList<Guess> calculateVariances(String guesses, int actualValue) throws JsonProcessingException;
}
