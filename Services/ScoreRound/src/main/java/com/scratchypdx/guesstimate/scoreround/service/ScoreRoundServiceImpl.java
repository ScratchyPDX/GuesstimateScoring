package com.scratchypdx.guesstimate.scoreround.service;

import com.scratchypdx.guesstimate.scoreround.model.Guess;
import com.scratchypdx.guesstimate.scoreround.model.Player;
import com.scratchypdx.guesstimate.scoreround.repository.PlayerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

@Service
public class ScoreRoundServiceImpl implements ScoreRoundService {
    @Autowired
    private PlayerRepository playerRepository;

    @Override
    public Player getPlayer(int id) {
        return playerRepository.getPlayer(id);
    }

    @Override
    public ArrayList<Player> getPlayers() {
        return playerRepository.getPlayers();
    }

    @Override
    public Player addPlayer(Player player) {
        return playerRepository.addPlayer(player);
    }

    @Override
    public void deletePlayer(Integer id) {
        playerRepository.deletePlayer(id);
    }

    @Override
    public void deleteAllPlayers() {
        playerRepository.deleteAllPlayers();
    }

    @Override
    public ArrayList<Player> scoreRound(ArrayList<Guess> guesses) {
        Collections.sort(guesses, new Comparator<Guess>() {
            @Override
            public int compare(Guess z1, Guess z2) {
                if (z1.getOverUnderValue() > z2.getOverUnderValue())
                    return 1;
                if (z1.getOverUnderValue() < z2.getOverUnderValue())
                    return -1;
                return 0;
            }
        });
        playerRepository.updatePlayerScore(guesses.get(0).getPlayerId(), 5);
        playerRepository.updatePlayerScore(guesses.get(1).getPlayerId(), 3);
        playerRepository.updatePlayerScore(guesses.get(2).getPlayerId(), 1);

        return playerRepository.getPlayers();
    }

    private void updatePlayerScore(Integer id, Integer score) {
        playerRepository.updatePlayerScore(id, score);
    }
}
