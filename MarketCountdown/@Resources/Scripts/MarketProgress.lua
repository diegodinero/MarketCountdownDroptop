-- Market Progress Script
-- Returns a 0-100% value representing progress through current market session

function GetProgress(marketName, timeZoneId, open1, close1, open2, close2)
    local os = require('os')
    
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
        local sessionDuration = c1 - o1
        local elapsed = currentMins - o1
        local progress = (elapsed / sessionDuration) * 100
        return math.floor(progress)
    end
    
    -- Check if open in session 2
    if open2 and close2 then
        local o2 = parseTime(open2)
        local c2 = parseTime(close2)
        if currentMins >= o2 and currentMins < c2 then
            local sessionDuration = c2 - o2
            local elapsed = currentMins - o2
            local progress = (elapsed / sessionDuration) * 100
            return math.floor(progress)
        end
    end
    
    -- Market is closed - show progress to next opening
    local lastClose = c1
    local nextOpen = o1
    
    if currentMins < o1 then
        -- Before first open today
        local downtimeMins = o1 - (1440 - (1440 - currentMins))  -- simplified
        local sinceClose = currentMins
        local progress = (sinceClose / (o1 - 0)) * 100
        return math.max(0, math.min(100, math.floor(progress)))
    else
        -- After close, before next day's open
        local downtimeMins = (1440 - currentMins) + o1
        local sinceClose = 1440 - currentMins
        local progress = (sinceClose / downtimeMins) * 100
        return math.max(0, math.min(100, math.floor(progress)))
    end
end

function Update()
    local marketName = SELF:GetOption('MarketName', 'London')
    local timeZoneId = SELF:GetOption('MarketTimeZone', 'GMT Standard Time')
    local open1 = SELF:GetOption('MarketOpen1', '08:00')
    local close1 = SELF:GetOption('MarketClose1', '17:00')
    local open2 = SELF:GetOption('MarketOpen2', nil)
    local close2 = SELF:GetOption('MarketClose2', nil)
    
    return GetProgress(marketName, timeZoneId, open1, close1, open2, close2)
end
