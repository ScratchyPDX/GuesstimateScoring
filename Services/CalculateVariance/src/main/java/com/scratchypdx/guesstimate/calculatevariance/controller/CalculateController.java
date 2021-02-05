package com.scratchypdx.guesstimate.calculatevariance.controller;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.scratchypdx.guesstimate.calculatevariance.model.Guess;
import com.scratchypdx.guesstimate.calculatevariance.service.CalculateService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import java.util.ArrayList;

@RestController
public class CalculateController {

    @Autowired
    private CalculateService calculateService;

    @PostMapping("/calc/guess/{guessValue}/actual/{actualValue}")
    //@ResponseBody
    public Integer calcVariance(@PathVariable("guessValue") Integer guessValue, @PathVariable("actualValue") Integer actualValue) {
        Integer result = calculateService.calculateVariance(guessValue, actualValue);
        return result;
    }

    @PostMapping("/calc/actual/{actualValue}")
    //@ResponseBody
    public ArrayList<Guess> getVariances(@RequestBody String guesses, @PathVariable("actualValue") Integer actualValue) throws JsonProcessingException {
        ArrayList<Guess> results = calculateService.calculateVariances(guesses, actualValue);
        return results;
    }
}
