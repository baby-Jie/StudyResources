package com.smx.model.mapper;

import com.smx.model.domain.User;

import java.util.List;

public interface UserMapper extends tk.mybatis.mapper.common.Mapper<User> {

    List<User> findAll();
}
