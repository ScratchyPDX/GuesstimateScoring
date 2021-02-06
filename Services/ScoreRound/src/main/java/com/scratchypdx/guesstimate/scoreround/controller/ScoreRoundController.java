package com.scratchypdx.guesstimate.scoreround.controller;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.scratchypdx.guesstimate.scoreround.model.Guess;
import com.scratchypdx.guesstimate.scoreround.model.Player;
import com.scratchypdx.guesstimate.scoreround.service.ScoreRoundService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import java.util.ArrayList;
import static com.scratchypdx.guesstimate.scoreround.util.HelperUtils.*;

@RestController
public class ScoreRoundController {

    @Autowired
    private ScoreRoundService scoreRoundService;

    @GetMapping("/player/Id/{playerId}")
    public Player getPlayer(@PathVariable("actualValue") Integer playerId) {
        Player player = new Player();
        return scoreRoundService.getPlayer(playerId);
    }

    @GetMapping("/player")
    public ArrayList<Player> getPlayers() {
        return scoreRoundService.getPlayers();
    }

    @PostMapping("/player")
    public Player addPlayer(@RequestBody String player) throws JsonProcessingException {
        return scoreRoundService.addPlayer(buildPlayerFromJsonString(player));
    }

    @PutMapping("/player/score")
    public ArrayList<Player> scoreRound(@RequestBody String guesses) throws JsonProcessingException {
        ArrayList<Guess> guessArrayList = buildGuessesFromJsonString(guesses);
        return scoreRoundService.scoreRound(guessArrayList);
    }

    @DeleteMapping("/player")
    public void deletePlayer(@RequestBody String player) throws JsonProcessingException {
        scoreRoundService.deletePlayer(buildPlayerFromJsonString(player));
    }

    @DeleteMapping("/player/all")
    public void deleteAllPlayer() {
        scoreRoundService.deleteAllPlayers();
    }
}
