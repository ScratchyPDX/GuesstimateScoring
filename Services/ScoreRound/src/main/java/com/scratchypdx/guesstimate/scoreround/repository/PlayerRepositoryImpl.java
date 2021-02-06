package com.scratchypdx.guesstimate.scoreround.repository;

import com.scratchypdx.guesstimate.scoreround.model.Guess;
import com.scratchypdx.guesstimate.scoreround.model.Player;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import javax.sql.DataSource;
import java.util.ArrayList;
import java.util.List;

@Repository
public class PlayerRepositoryImpl implements PlayerRepository {

    @Autowired
    private DataSource dataSource;

    @Override
    public Player getPlayer(int id) {
        JdbcTemplate template = new JdbcTemplate(dataSource);
        return template.queryForObject("select id, name, score from players.players where id = ?",
            (resultSet, i) -> {
                Player rsPlayer = new Player();
                rsPlayer.setId(resultSet.getInt("id"));
                rsPlayer.setName(resultSet.getString("name"));
                rsPlayer.setScore(resultSet.getInt("score"));
                return rsPlayer;
            }, id);
    }

    public Player getPlayer(String name) {
        JdbcTemplate template = new JdbcTemplate(dataSource);
        return template.queryForObject("select id, name, score from players.players where name = ?",
            (resultSet, i) -> {
                Player rsPlayer = new Player();
                rsPlayer.setId(resultSet.getInt("id"));
                rsPlayer.setName(resultSet.getString("name"));
                rsPlayer.setScore(resultSet.getInt("score"));
                return rsPlayer;
            }, name);
    }

    @Override
    public ArrayList<Player> getPlayers() {
        JdbcTemplate template = new JdbcTemplate(dataSource);
        List<Player> playersList = template.query("select id, name, score from players.players",
            (rs, rowNum) -> new Player(rs.getInt("id"), rs.getString("name"),
                rs.getInt("score")));
        return new ArrayList(playersList);
    }

    @Override
    public Player addPlayer(Player player) {
        JdbcTemplate template = new JdbcTemplate(dataSource);
        template.update("INSERT INTO players.players (name, score) VALUES (?,?)",
                player.getName(),
                player.getScore());
        return getPlayer(player.getName());
    }

    @Override
    public Player updatePlayerScore(Integer id, Integer score) {
        JdbcTemplate template = new JdbcTemplate(dataSource);
        template.update("UPDATE players.players SET score = ? where id = ?;\n",
                score,
                id);
        return getPlayer(id);
    }

    @Override
    public void deletePlayer(Integer id) {
        JdbcTemplate template = new JdbcTemplate(dataSource);
        template.update("DELETE FROM players.players where id = ?", id);
    }

    @Override
    public void deleteAllPlayers() {
        JdbcTemplate template = new JdbcTemplate(dataSource);
        template.update("DELETE FROM players.players");

    }
}
