package com.scratchy.guess;

import com.microsoft.azure.functions.*;
import com.microsoft.azure.functions.annotation.AuthorizationLevel;
import com.microsoft.azure.functions.annotation.FunctionName;
import com.microsoft.azure.functions.annotation.HttpTrigger;
import com.scratchy.guess.model.Guess;
import com.scratchy.guess.service.GuessService;
import com.scratchy.guess.service.GuessServiceImpl;

import java.util.ArrayList;

public class Function {

    @FunctionName("Guess")
    public HttpResponseMessage run(
            @HttpTrigger(
                    name = "req",
                    methods = {HttpMethod.POST},
                    route = "Guess/{actualValue:int}",
                    authLevel = AuthorizationLevel.ANONYMOUS)
                    HttpRequestMessage<ArrayList<Guess>> request,
            final ExecutionContext context) {

        String[] parameters = request.getUri().getPath().split("/");
        int actualValue = Integer.parseInt(parameters[3]);
        GuessService guessService = new GuessServiceImpl();
        ArrayList<Guess> guesses = request.getBody();
        ArrayList<Guess> results = guessService.calculateVariances(guesses, actualValue);
        return request.createResponseBuilder(HttpStatus.OK).body(results).build();
    }
}
