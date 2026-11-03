-- Market Display Script
-- Shows time until market open (negative) or time since market open (positive)

function GetDisplay(marketName, timeZoneId, open1, close1, open2, close2)
    local os = require('os')
    
    -- Get current time (simplified - assumes local time is close enough for demo)
    local now = os.time()
    local nowDate = os.date('*t', now)
    local currentMins = nowDate.hour * 60 + nowDate.min
    
    -- Parse times
    local function parseTime(timeStr)
        local h, m = timeStr:match('(%d+):(%d+)')
        return tonumber(h) * 60 + tonumber(m)
    end
    
    local o1 = parseTime(open1)
    local c1 = parseTime(close1)
    
    -- Check if currently open in session 1
    if currentMins >= o1 and currentMins < c1 then
        local sinceMins = currentMins - o1
        local hrs = math.floor(sinceMins / 60)
        local mins = sinceMins % 60
        return string.format('+%02d:%02d', hrs, mins)
    end
    
    -- Check if open in session 2
    if open2 and close2 then
        local o2 = parseTime(open2)
        local c2 = parseTime(close2)
        if currentMins >= o2 and currentMins < c2 then
            local sinceMins = currentMins - o2
            local hrs = math.floor(sinceMins / 60)
            local mins = sinceMins % 60
            return string.format('+%02d:%02d', hrs, mins)
        end
    end
    
    -- Market is closed - calculate time until next open
    local nextOpen = o1
    if currentMins >= c1 then
        -- Already past close, next open is tomorrow
        nextOpen = o1
        local untilMins = (1440 - currentMins) + nextOpen  -- 1440 = 24 hours in minutes
        local hrs = math.floor(untilMins / 60)
        local mins = untilMins % 60
        return string.format('-%02d:%02d', hrs, mins)
    else
        -- Before open today
        local untilMins = nextOpen - currentMins
        local hrs = math.floor(untilMins / 60)
        local mins = untilMins % 60
        return string.format('-%02d:%02d', hrs, mins)
    end
end

function Update()
    local marketName = SELF:GetOption('MarketName', 'London')
    local timeZoneId = SELF:GetOption('MarketTimeZone', 'GMT Standard Time')
    local open1 = SELF:GetOption('MarketOpen1', '08:00')
    local close1 = SELF:GetOption('MarketClose1', '17:00')
    local open2 = SELF:GetOption('MarketOpen2', nil)
    local close2 = SELF:GetOption('MarketClose2', nil)
    
    return GetDisplay(marketName, timeZoneId, open1, close1, open2, close2)
end
