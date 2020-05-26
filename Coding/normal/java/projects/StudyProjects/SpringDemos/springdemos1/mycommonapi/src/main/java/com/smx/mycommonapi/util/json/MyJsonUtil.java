package com.smx.mycommonapi.util.json;

import com.alibaba.fastjson.JSONArray;
import com.alibaba.fastjson.JSONObject;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * 自己的 Json 工具类
 */
public class MyJsonUtil {

    // region json2Object 将json转化为实体 POJO

    /**
     * 将json转化为实体 POJO
     *
     * @param json
     * @param clazz
     * @param <T>
     * @return
     */
    public static <T> Object json2Object(String json, Class<T> clazz) {

        T t = null;
        try {
            ObjectMapper objectMapper = new ObjectMapper();
            t = objectMapper.readValue(json, clazz);
        } catch (Exception e) {

        }
        return t;
    }
    // endregion json2Object

    // region object2Json 实体 POJO 转化为 json 字符串

    /**
     * 实体 POJO 转化为 json 字符串
     *
     * @param object
     * @return
     */
    public static String object2Json(Object object) {
        return object2Json(object, 0);
    }

    /**
     * 实体 POJO 转化为 json 字符串
     *
     * @param object
     * @param processType
     * @return
     */
    public static String object2Json(Object object, int processType) {
        String json = null;

        int maxVal = JsonInclude.Include.values().length;

        if (processType >= maxVal || processType < 0) {
            processType = 0;
        }

        JsonInclude.Include include = JsonInclude.Include.values()[processType];

        try {
            if (object != null) {
                ObjectMapper objectMapper = new ObjectMapper();
                objectMapper.setSerializationInclusion(include);
                json = objectMapper.writeValueAsString(object);
            }
        } catch (Exception e) {
        }
        return json;
    }
    // endregion object2Json

    // region object2JsonObject 将实体 POJO 转化为JSONObject

    /**
     * 将实体 POJO 转化为JSONObject
     *
     * @param object
     * @return
     */
    public static JSONObject object2JsonObject(Object object) {
        return object2JsonObject(object);
    }

    /**
     * 将实体 POJO 转化为JSONObject
     *
     * @param object
     * @param processType
     * @return
     */
    public static JSONObject object2JsonObject(Object object, int processType) {
        return JSONObject.parseObject(object2Json(object, processType));
    }
    // endregion object2JsonObject

    // region object2JsonArray 将实体POJO转化为JSONArray

    /**
     * 将实体POJO转化为JSONArray
     *
     * @param object
     * @return
     */
    public static JSONArray object2JsonArray(Object object) {
        return object2JsonArray(object);
    }

    /**
     * 将实体POJO转化为JSONArray
     *
     * @param object
     * @param processType
     * @return
     */
    public static JSONArray object2JsonArray(Object object, int processType) {
        return JSONArray.parseArray(object2Json(object, processType));
    }
    // endregion object2JsonArray

    // region jsonObj2Map 将JSONObject 转化为HashMap

    /**
     * 将JSONObject转化为HashMap 其实没有必要 其实 JSONObject本身就是map
     *
     * @param jsonObject
     * @return
     */
    public static Map<String, Object> jsonObj2Map(JSONObject jsonObject) {

        Map<String, Object> outMap = new HashMap<String, Object>();
        if (null != jsonObject) {
            for (String key : jsonObject.keySet()) {
                outMap.put(key, jsonObject.get(key));
            }
        }
        return outMap;
    }
    // endregion jsonObj2Map

    // region jsonArray2MapList 将jsonArray转化为List<Map>

    public static List<Map<String, Object>> jsonArray2MapList(JSONArray jsonArray) throws Exception{
        List<Map<String,Object>> list = new ArrayList<Map<String,Object>>();
        for (int i = 0; i < jsonArray.size(); i++) {
            list.add(jsonObj2Map(jsonArray.getJSONObject(i)));
        }
        return list;
    }
    // endregion jsonArray2MapList
    
    // region jsonArray2StringList 将JSONArray转化为List<String>

    public static List<String> jsonArray2StringList(JSONArray jsonArray){
        List<String> list = new ArrayList<String>();
        if(jsonArray != null && jsonArray.size() > 0){
            for (int i = 0; i < jsonArray.size(); i++) {
                list.add(jsonArray.getString(i));
            }
        }
        return list;
    }
    // endregion 将JSONArray转化为List<String>
}
