package com.scratchypdx.guesstimate.calculatevariance.controller;

import com.fasterxml.jackson.core.JsonFactory;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.ObjectReader;
import com.scratchypdx.guesstimate.calculatevariance.model.Guess;
import com.scratchypdx.guesstimate.calculatevariance.service.CalculateService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

@RestController
public class CalculateController {

    @Autowired
    private CalculateService calculateService;

    @RequestMapping("/calc/guess/{guessValue}/actual/{actualValue}")
    //@ResponseBody
    public Integer calcVariance(@PathVariable("guessValue") Integer guessValue, @PathVariable("actualValue") Integer actualValue) {
        System.out.println("calcVariance: guessValue=" + guessValue);
        System.out.println("calcVariance: actualValue=" + actualValue);
        System.out.println("calcVariance: before call to calculateVariance");
        Integer result = calculateService.calculateVariance(guessValue, actualValue);
        System.out.println("calcVariance: after call to calculateVariance");
        System.out.println("calcVariance: result=" + result);
        return result;
    }

    @PostMapping("/calc/actual/{actualValue}")
    //@ResponseBody
    public ArrayList<Guess> getVariances(@RequestBody String guesses, @PathVariable("actualValue") Integer actualValue) throws JsonProcessingException {
        ObjectMapper objectMapper = new ObjectMapper();
        ObjectReader objectReader = objectMapper.reader().forType(new TypeReference<ArrayList<Guess>>(){});
        ArrayList<Guess> guessesArrayList = objectReader.readValue(guesses);

        System.out.println("getVariance: actualValue=" + actualValue);
        System.out.println("getVariance: guesses=" + guesses);
        System.out.println("getVariance: before call to calculateVariance");
        ArrayList<Guess> results = calculateService.calculateVariances(guessesArrayList, actualValue);
        System.out.println("getVariance: after call to calculateVariance");
        return results;
    }
}
