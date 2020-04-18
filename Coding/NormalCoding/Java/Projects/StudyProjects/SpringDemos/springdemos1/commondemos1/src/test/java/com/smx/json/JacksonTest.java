package com.smx.json;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.core.JsonGenerator;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.SerializationConfig;
import com.smx.commondemos1.model.entity.Student;
import com.smx.mycommonapi.model.User;
import org.junit.Test;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

public class JacksonTest {

    // region 序列化
    @Test
    public void testSerialize() throws Exception {

        User user = new User(1, "smx", 100);

        List<User> userList = new ArrayList<>();
        userList.add(user);
        userList.add(new User(2, "xyj", 99));

        ObjectMapper objectMapper = new ObjectMapper();

        // 1. 对象序列化
        String json = objectMapper.writeValueAsString(user);

        // 2. list 序列化
        String listJson = objectMapper.writeValueAsString(userList);
        System.out.println("json is:" + json);
        System.out.println("listJson is: " + listJson);
    }
    // endregion 序列化

    // region 反序列化

    @Test
    public void testUnSerialization() throws Exception {

        User user = new User(1, "smx", 100);
        ObjectMapper objectMapper = new ObjectMapper();
        String userJson = objectMapper.writeValueAsString(user);
        List<User> userList = new ArrayList<>();
        userList.add(user);
        userList.add(new User(2, "xyj", 99));
        String listJson = objectMapper.writeValueAsString(userList);

        // 1. 反序列化对象
        User deUser = objectMapper.readValue(userJson, User.class);
        System.out.println(deUser);

        // 2. 反序列化list
        List<User> deList = objectMapper.readValue(listJson, List.class);
        System.out.println(deList);
    }

    // endregion 反序列化

    // region 注解 自定义序列化

    /**
     * 使用注解来自定义序列化
     * 1. 使用@JsonIgnore 来 限制某个字段 序列化 @JsonIgnoreProperties 和 @JsonIgnore 的作用相同，都是告诉 Jackson 该忽略哪些属性, 不同之处是 @JsonIgnoreProperties 是类级别的，并且可以同时指定多个属性
     * 2. 使用@JsonInclude 来 限制某个字段 序列化
     *      Include.NON_NULL：为null值时，不序列化
     *      Include.NON_EMPTY: 为empty时，不序列化("" and NULL)
     *      Include.NON_DEFAULT: 为默认值时，不序列化。
     * 3. @JsonIgnoreType 标注在类上，当其他类有该类作为属性时，该属性将被忽略。
     * 4. @JsonProperty 可以指定某个属性和json映射的名称。
     * 5. @JsonPropertyOrder 在将 java pojo 对象序列化成为 json 字符串时，使用 @JsonPropertyOrder 可以指定属性在 json 字符串中的顺序。一般放在类上面
     * 6. @JsonSetter 标注于 setter 方法上，类似 @JsonProperty ，也可以解决 json 键名称和 java pojo 字段名称不匹配的问题。
     * @throws JsonProcessingException
     */
    @Test
    public void testAnnotation() throws JsonProcessingException {

        Student student = new Student("smx", 18, 100.5f);
        Student student1 = new Student("", 19, 1.f);
        Student student2 = new Student();
        student2.setAge(18);
        student2.setScore(2.9f);

        ObjectMapper objectMapper = new ObjectMapper();
        objectMapper.setSerializationInclusion(JsonInclude.Include.NON_NULL);
        String json = objectMapper.writeValueAsString(student);
        String json1 = objectMapper.writeValueAsString(student1);
        String json2 = objectMapper.writeValueAsString(student2);
//        Student deStudent = objectMapper.readValue(json2, Student.class);

        System.out.println(json2);
    }

    // endregion 注解 自定义序列化

    // region ObjectMapper 自定义序列化

    @Test
    public void testCustomSerialization() throws Exception{

        // 使用Include.Custom 失败 原因未知。
        ObjectMapper objectMapper = new ObjectMapper();
        Student student = new Student("smx", 180, 100.5f);
//        SerializationConfig serializationConfig = objectMapper.getSerializationConfig();
//        serializationConfig.withFeatures(JsonGenerator.Feature.AUTO_CLOSE_TARGET);

        String json = objectMapper.writeValueAsString(student);

//        mapper.setDateFormat(new SimpleDateFormat("yyyy-MM-dd HH:mm:ss"));
        System.out.println(json);
    }

    // endregion
}
