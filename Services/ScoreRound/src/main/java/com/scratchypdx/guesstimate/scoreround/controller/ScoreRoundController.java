package com.scratchypdx.guesstimate.scoreround.controller;

import com.scratchypdx.guesstimate.scoreround.model.Guess;
import com.scratchypdx.guesstimate.scoreround.model.Player;
import com.scratchypdx.guesstimate.scoreround.service.ScoreRoundService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import java.util.ArrayList;

@RestController
public class ScoreRoundController {

    @Autowired
    private ScoreRoundService scoreRoundService;

    @GetMapping("/player/Id/{id}")
    public Player getPlayer(@PathVariable("id") Integer playerId) {
        Player player = new Player();
        return scoreRoundService.getPlayer(playerId);
    }

    @GetMapping("/player")
    public ArrayList<Player> getPlayers() {
        return scoreRoundService.getPlayers();
    }

    @PostMapping("/player/{name}")
    public Player addPlayer(@PathVariable String name) {
        return scoreRoundService.addPlayer(name);
    }

    @PostMapping("/player")
    public Player addPlayer(@RequestBody Player player) {
        return scoreRoundService.addPlayer(player);
    }

    @PutMapping("/player/score/all")
    public ArrayList<Player> scoreRound(@RequestBody ArrayList<Guess> guesses) {
        return scoreRoundService.scoreRound(guesses);
    }

    @DeleteMapping("/player/{id}")
    public void deletePlayer(@PathVariable("id") Integer playerId)  {
        scoreRoundService.deletePlayer(playerId);
    }

    @DeleteMapping("/player/all")
    public void deleteAllPlayer() {
        scoreRoundService.deleteAllPlayers();
    }
}
