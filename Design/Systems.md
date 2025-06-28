# 游戏系统设计文档

## 1. 天气系统 (Weather System)

### 系统概述
天气系统控制游戏世界的环境变化，影响资源生产、事件触发和玩家决策。

### 核心字段
```json
{
  "weatherType": "Rain|Drought|Storm|Clear|Fog|Wind",
  "intensity": 0.0-1.0,
  "duration": 1-10,
  "affectedResources": ["RES001", "RES002"],
  "eventModifiers": {
    "disasterChance": 0.1,
    "consciousnessChance": 0.05
  }
}
```

### 天气类型效果
- **降雨 (Rain)**: 提升水资源产量，增加洪水风险
- **干旱 (Drought)**: 降低水资源和食物产量，增加火灾风险
- **风暴 (Storm)**: 降低所有资源产量，增加灾害事件概率
- **晴朗 (Clear)**: 正常生产，提升人口满意度
- **雾霾 (Fog)**: 降低视野，影响建筑效率
- **大风 (Wind)**: 提升风力发电，增加火灾风险

### 系统机制
- 天气每回合自动变化
- 连续相同天气增加相关事件概率
- 建筑可以影响局部天气
- 和谐度影响天气变化频率

## 2. 元素活动系统 (Element Activity System)

### 系统概述
自然元素的活动系统控制元素的活跃程度，影响资源产量和事件触发。

### 核心字段
```json
{
  "elementID": "NAT001",
  "activityLevel": "Low|Medium|High|Critical",
  "activityType": "Peaceful|Agitated|Hostile|Cooperative",
  "influenceRange": 0.0-1.0,
  "regenerationModifier": 0.5-2.0,
  "eventTriggerChance": 0.0-0.5
}
```

### 活动等级效果
- **低活动 (Low)**: 正常生产，低事件概率
- **中等活动 (Medium)**: 提升生产，中等事件概率
- **高活动 (High)**: 大幅提升生产，高事件概率
- **临界活动 (Critical)**: 极高生产，极高事件概率

### 活动类型效果
- **和平 (Peaceful)**: 稳定生产，低冲突概率
- **躁动 (Agitated)**: 生产波动，中等冲突概率
- **敌对 (Hostile)**: 生产下降，高冲突概率
- **合作 (Cooperative)**: 生产提升，低冲突概率

## 3. 和谐度系统 (Harmony System)

### 系统概述
和谐度系统衡量玩家与自然元素的关系，影响资源获取、事件触发和外交成功率。

### 核心字段
```json
{
  "elementID": "NAT001",
  "harmonyValue": 0.0-1.0,
  "harmonyTrend": "Increasing|Decreasing|Stable",
  "relationshipLevel": "Hostile|Neutral|Friendly|Allied",
  "bonusEffects": {
    "resourceBoost": 0.0-0.5,
    "eventChance": 0.0-0.3,
    "diplomaticSuccess": 0.0-0.4
  }
}
```

### 和谐度等级
- **0.0-0.2**: 敌对关系，资源产量下降，高冲突概率
- **0.2-0.4**: 紧张关系，资源产量略降，中等冲突概率
- **0.4-0.6**: 中立关系，正常生产，低冲突概率
- **0.6-0.8**: 友好关系，资源产量提升，低冲突概率
- **0.8-1.0**: 联盟关系，大幅提升产量，极低冲突概率

### 影响因素
- 建筑类型和数量
- 资源开采强度
- 环境保护措施
- 外交协议等级
- 历史行为记录

## 4. 外交等级系统 (Diplomatic Level System)

### 系统概述
外交等级系统管理玩家与自然元素的外交关系，影响协议签署和效果。

### 核心字段
```json
{
  "elementID": "NAT001",
  "diplomaticLevel": 1-6,
  "relationshipValue": 0.0-1.0,
  "trustLevel": 0.0-1.0,
  "agreementSlots": 1-3,
  "unlockedAgreements": ["Protection", "Cooperation", "Alliance"]
}
```

### 外交等级效果
- **等级1**: 无协议，基础关系
- **等级2**: 可签署保护协议
- **等级3**: 可签署合作协议
- **等级4**: 可签署伙伴关系
- **等级5**: 可签署联盟关系
- **等级6**: 可签署深度联盟

### 升级条件
- 和谐度达到要求
- 完成特定任务
- 投入外交资源
- 时间积累

## 5. 环境质量系统 (Environmental Quality System)

### 系统概述
环境质量系统评估整体环境状况，影响人口满意度和资源生产。

### 核心字段
```json
{
  "environmentalQuality": 0.0-1.0,
  "pollutionLevel": 0.0-1.0,
  "biodiversityIndex": 0.0-1.0,
  "sustainabilityScore": 0.0-1.0,
  "globalEffects": {
    "populationSatisfaction": 0.5-1.5,
    "resourceEfficiency": 0.5-1.5,
    "eventFrequency": 0.5-1.5
  }
}
```

### 质量等级
- **0.0-0.2**: 极差环境，人口满意度极低，资源效率极低
- **0.2-0.4**: 差环境，人口满意度低，资源效率低
- **0.4-0.6**: 一般环境，正常满意度，正常效率
- **0.6-0.8**: 好环境，高满意度，高效率
- **0.8-1.0**: 极好环境，极高满意度，极高效率

### 影响因素
- 建筑类型和密度
- 资源开采强度
- 环境保护措施
- 自然元素状态
- 历史环境记录

## 6. 技术等级系统 (Technology Level System)

### 系统概述
技术等级系统管理玩家的科技发展，解锁新建筑、措施和功能。

### 核心字段
```json
{
  "technologyID": "TECH001",
  "technologyLevel": 1-10,
  "researchProgress": 0.0-1.0,
  "unlockedFeatures": ["Building", "Measure", "Ability"],
  "researchCost": {
    "knowledge": 100,
    "scientists": 5,
    "time": 10
  }
}
```

### 技术类型
- **基础技术**: 解锁基础建筑和功能
- **共生技术**: 提升与自然的和谐关系
- **防范技术**: 增强灾害防护能力
- **消除技术**: 提供环境改造能力
- **利用技术**: 最大化资源获取效率

### 升级机制
- 投入知识资源
- 分配科学家研究
- 时间积累
- 完成特定条件

## 7. 人口系统 (Population System)

### 系统概述
人口系统管理不同类型的人口，影响资源生产和建筑效率。

### 核心字段
```json
{
  "populationType": "Workers|Specialists|Scientists|Managers",
  "populationCount": 0-100,
  "satisfactionLevel": 0.0-1.0,
  "efficiencyModifier": 0.5-1.5,
  "resourceConsumption": {
    "food": 1.0,
    "water": 0.5,
    "energy": 0.3
  }
}
```

### 人口类型特性
- **工人 (Workers)**: 基础劳动力，消耗少，效率一般
- **专家 (Specialists)**: 高级技能，消耗中等，效率高
- **科学家 (Scientists)**: 研究能力，消耗高，研究效率高
- **管理者 (Managers)**: 管理能力，消耗最高，管理效率高

### 满意度影响
- 环境质量
- 资源供应
- 建筑设施
- 事件影响
- 和谐度

## 8. 建筑类型系统 (Building Type System)

### 系统概述
建筑类型系统定义各种建筑的特性和功能。

### 核心字段
```json
{
  "buildingType": "Dam|FireStation|VolcanoControl|EarthquakeResistant",
  "buildingCategory": "Defensive|Production|Research|Residential",
  "buildingLevel": 1-5,
  "efficiency": 0.5-2.0,
  "maintenanceCost": {
    "resources": ["RES001", "RES002"],
    "amounts": [10, 5]
  }
}
```

### 建筑分类
- **防御建筑**: 防护自然灾害和意识冲突
- **生产建筑**: 生产各种资源
- **研究建筑**: 提升科技发展
- **居住建筑**: 容纳人口
- **共生建筑**: 与自然元素和谐共存
- **消除建筑**: 改造环境和消除意识

### 建筑特性
- 意识觉醒概率
- 环境影响程度
- 升级可能性
- 特殊功能

## 9. 事件触发系统 (Event Trigger System)

### 系统概述
事件触发系统根据各种条件自动触发游戏事件。

### 核心字段
```json
{
  "triggerCondition": "ResourceLevel|WeatherCondition|BuildingCount|HarmonyLevel",
  "conditionValue": 0.0-1.0,
  "triggerChance": 0.0-1.0,
  "cooldownPeriod": 1-20,
  "priority": 1-10
}
```

### 触发条件类型
- **资源条件**: 资源储量达到阈值
- **天气条件**: 特定天气持续一定时间
- **建筑条件**: 特定建筑数量达到要求
- **和谐度条件**: 与自然元素关系达到要求
- **技术条件**: 特定技术等级达到要求
- **人口条件**: 特定人口数量达到要求

### 触发机制
- 每回合检查所有条件
- 满足条件时计算触发概率
- 成功触发后进入冷却期
- 优先级高的事件优先触发

## 10. 效果系统 (Effect System)

### 系统概述
效果系统管理各种游戏效果，包括资源变化、建筑影响、人口影响等。

### 核心字段
```json
{
  "effectType": "ResourceBoost|HarmonyGain|BuildingDamage|PopulationPenalty",
  "target": "RES001|NAT001|BuildingType|PopulationType",
  "value": -1.0-2.0,
  "duration": 1-50,
  "description": "效果描述"
}
```

### 效果类型
- **资源效果**: 影响资源产量和储量
- **和谐度效果**: 影响与自然元素的关系
- **建筑效果**: 影响建筑效率和状态
- **人口效果**: 影响人口满意度和效率
- **环境效果**: 影响环境质量
- **事件效果**: 影响事件触发概率

### 效果机制
- 立即效果和持续效果
- 正面效果和负面效果
- 叠加效果和互斥效果
- 条件效果和概率效果

## 系统交互关系

### 核心循环
1. **天气系统** → 影响资源生产和事件触发
2. **元素活动系统** → 影响和谐度和外交关系
3. **和谐度系统** → 影响外交等级和资源获取
4. **外交等级系统** → 影响协议效果和事件概率
5. **环境质量系统** → 影响人口满意度和整体效率
6. **技术等级系统** → 解锁新功能和提升效率
7. **人口系统** → 影响资源生产和建筑效率
8. **建筑类型系统** → 影响环境质量和资源生产
9. **事件触发系统** → 根据各种条件触发事件
10. **效果系统** → 管理所有变化和影响

### 平衡机制
- 各系统相互制约，保持游戏平衡
- 正面效果需要投入资源和时间
- 负面效果可以通过预防措施避免
- 长期策略比短期收益更重要 