package com.smx.springintergrations.model.entity.mapper;

import com.smx.mycommonapi.model.User;
import org.apache.ibatis.annotations.Mapper;

import java.util.List;

@Mapper
public interface UserMapper {

    public List<User> findAll();
}
