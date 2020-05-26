package com.smx.springintergrations.model.entity.mapper;

import com.smx.springintergrations.model.entity.domain.Account;
import com.smx.springintergrations.template.BaseMapper;
import org.apache.ibatis.annotations.Param;
import org.apache.ibatis.annotations.Select;

import java.util.List;

public interface AccountMapper extends BaseMapper<Account> {

    List<Account> findAll();

    List<Account> findSpecific(Account account);

    @Select("${sql}")
    List<Account> findSpecificSql(@Param("sql")String sql);

    List<Account> findSpecificOrderBy(@Param("isName")String isName);

    List<Account> findConcat(@Param("name")String name);

    List<Account> testBind(@Param("sortColumn")String sortColumn, @Param("sortRule")String sortRule);

    List<Account> testIf(@Param("sortColumn")String sortColumn, @Param("sortBy")String sortBy);
}
